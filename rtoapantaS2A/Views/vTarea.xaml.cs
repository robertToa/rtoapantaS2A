namespace rtoapantaS2A.Views;

public partial class vTarea : ContentPage
{
	public vTarea()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (validarCampos())
        {
            double segumiento1 = double.Parse(txtSeguimiento1.Text);
            double notaExamen1 = double.Parse(txtNotaExamen1.Text);
            double segumiento2 = double.Parse(txtSeguimiento2.Text);
            double notaExamen2 = double.Parse(txtNotaExamen2.Text);
            double notaParcial1 = calcularParcial(segumiento1, notaExamen1);
            double notaParcial2 = calcularParcial(segumiento2, notaExamen2);
            double notaFinal = calcularParcial(notaParcial1, notaParcial2);
            string aprobacion = ObtenerEstadoAprobacion(notaFinal);

            txtParcial1.Text = notaParcial1.ToString("0.00");
            txtParcial2.Text = notaParcial2.ToString("0.00");
            txtFinal.Text = notaFinal.ToString("0.00");
            txtEstadoAprobacion.Text = aprobacion;
            imprimir();
        }
    }

    private void imprimir()
    {
        string fecha = dpkFecha.Date?.ToString("dd/MM/yyyy");
        DisplayAlert("Resultado", $"Nombre: {pckEstudiantes.SelectedItem}\n" +
                                      $"Fecha: {fecha}\n" +
                                      $"Nota Parcial 1: {txtParcial1.Text}\n" +
                                      $"Nota Parcial 2: {txtParcial2.Text}\n" +
                                      $"Nota Final: {txtFinal.Text}\n" +
                                      $"Estado de Aprobación: {txtEstadoAprobacion.Text}", "OK");
    }

    private bool validarCampos()
    {
        if (pckEstudiantes.SelectedItem == null)
        {
            DisplayAlertAsync("Error", "Por favor, seleccione un estudiante", "OK");
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtSeguimiento1.Text) || string.IsNullOrWhiteSpace(txtNotaExamen1.Text) ||
            string.IsNullOrWhiteSpace(txtSeguimiento2.Text) || string.IsNullOrWhiteSpace(txtNotaExamen2.Text))
        {
            DisplayAlert("Error", "Por favor, ingrese todos los campos requeridos.", "OK");
            return false;
        }
        if (!validarNota(txtSeguimiento1.Text) || !validarNota(txtNotaExamen1.Text) ||
            !validarNota(txtSeguimiento2.Text) || !validarNota(txtNotaExamen2.Text))
        {
            DisplayAlert("Error", "Las notas deben ser números entre 0 y 10.", "OK");
            return false;
        }
        return true;
    }

    private bool validarNota(string nota)
    {
        if (!double.TryParse(nota, out double valor))
            return false;

        if (valor < 0 || valor > 10)
            return false;

        return true;
    }

    private string ObtenerEstadoAprobacion(double nota)
    {
        return nota >= 7 ? "Aprobado" : nota >= 5 && nota < 7 ? "Complementario" : "Reprobado";
    }


	private double calcularParcial(double nota1, double nota2)
    {
        double n1 = nota1;
        double n2 = nota2;
        return (n1 + n2) / 2;
    }
}