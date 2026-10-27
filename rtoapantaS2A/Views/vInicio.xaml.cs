namespace rtoapantaS2A.Views;

public partial class vInicio : ContentPage
{
	public vInicio()
	{
		InitializeComponent();
	}

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {

		if(pckPaises.SelectedItem == null)
		{
			DisplayAlertAsync("Error", "Por favor, seleccione un país.", "OK");
			return;
		}
		string nombre = txtDato.Text;
        string pais = pckPaises.SelectedItem?.ToString() ?? "No seleccionado";
        string fecha = dpkFecha.Date?.ToString("dd/MM/yyyy");
        DisplayAlertAsync("País seleccionado", "Bienvenido  "+ nombre + "\nEl país seleccionado es: " + pais + 
			"\nLa fecha seleccionada es: " + fecha, "OK");
    }

	private async void btnAbrir_Clicked(object sender, EventArgs e)
	{ 
		await Navigation.PushAsync(new Views.vTarea());
    }
}