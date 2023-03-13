using AsistenciaDUAL.Models;
using Plugin.CloudFirestore;

namespace AsistenciaDUAL;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AsistenciasHoy();
    }

    private void AsistenciasHoy() 
	{
        int epoch = EpochConverter.DateToEpoch(DateTime.Today);
        MostrarAsistencias(epoch);
    }

    private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
		tvTabla.Clear();
		int epoch = EpochConverter.DateToEpoch(((DatePicker)sender).Date);
        MostrarAsistencias(epoch);
    }

	private async void MostrarAsistencias(int epoch)
	{
        var document = await CrossCloudFirestore
                                            .Current
                                            .Instance
                                            .Collection("Epoch")
                                            .Document((epoch / 86400).ToString())
                                            .GetAsync();

        if (document.Data != null)
        {
            List<string> keys = document.Data.Keys.ToList();
            var values = document.Data.Values.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                TextCell item = new TextCell();
                string Entrada = string.Empty;
                string Salida = string.Empty;
                string s = keys[i];
                item.Text = DiccionarioAlumnos.ValidarAlumno(keys[i]);
                if (keys[i][keys[i].Length - 1] == 'S') continue;

                if (keys[i][keys[i].Length - 1] == 'E')
                {
                    Entrada = values[i].ToString();
                    if (EncontrarSalidaAlumno(keys[i], keys) == -1000)
                    {
                        Salida = "No registrada";
                    }
                    else
                    {
                        string salidaString = values[EncontrarSalidaAlumno(keys[i], keys)].ToString();

                        Salida = GetDate(EpochConverter.EpochToDate(int.Parse(salidaString)));
                    }
                }
                item.Detail = $"Entrada: {GetDate(EpochConverter.EpochToDate(int.Parse(Entrada)))}, Salida: {Salida}";
                tvTabla.Add(item);
            }

        }
    }

	private int EncontrarSalidaAlumno(string keyWLastLetter, List<string> keys)
	{
		string key = subStringS(keyWLastLetter) + "S";
		for(int i = 0; i < keys.Count; i++)
		{
			if(key == keys[i])
			{
				return i;
			}
		}
		return -1000;
	}

    private string subStringS(string key)
    {
        string newKey = string.Empty;
        for (int i = 0; i < key.Length - 1; i++)
        {
            newKey += key[i];
        }
        return newKey;
    }

	private string GetDate(string date)
	{
		string newDate = string.Empty;
		for (int i = 0; i < date.Length - 6; i++) 
		{
			newDate += date[i];
		}
		return newDate;
	}
}

