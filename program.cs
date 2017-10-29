using System;

class Programa{

	public static void Main(string[] args){
		Programa.crearMenu("Titulo prueba aplicación","Autor: Akira94");	
	}

	private static void crearMenu(string titulo, string autor){
		
	}
	
	//método para dibujar Menú en consola
	private static void dibujarMenu(int x, int y, int x1, int y1){
		//Console.WriteLine("x={0}, x1={1}, y={2}, y1={3}",x,x1,y,y1);

		for (int i = x; i <= x1; i++) {

			if (i == x) {
				Console.SetCursorPosition (i, y);
				Console.WriteLine ("╔");
			} else if (i == x1) {
				Console.SetCursorPosition (i, y);
				Console.WriteLine ("╗");
			} else {
				Console.SetCursorPosition (i, y);
				Console.WriteLine ("═");	
			}
		}

		for (int i = x; i <= x1; i++) {

			if (i == x) {
				Console.SetCursorPosition (i, y1);
				Console.WriteLine ("╚");
			} else if (i == x1) {
				Console.SetCursorPosition (i, y1);
				Console.WriteLine ("╝");
			} else {
				Console.SetCursorPosition (i, y1);
				Console.WriteLine ("═");	
			}
		}
			
		for (int i = y+1; i <= y1-1; i++) {
			Console.SetCursorPosition (x, i);
			Console.WriteLine ("║");
		}

		for (int i = y+1; i <= y1-1; i++) {
			Console.SetCursorPosition (x1, i);
			Console.WriteLine ("║");
		}
	}

	//método para imprimir mensajes en pantalla
	private static void escribirMensaje(int x, int y, string mensaje){
		Console.SetCursorPosition(x,y);
		Console.Write(mensaje);
	}

	//método para determinar intervalo de tiempo entre dos fechas
	public static void diasFechaNacimiento(){
			
		Console.WriteLine(DateTime.Now);
		string anio, mes, dia;
		int comprobacion;
		string opcion;
		DateTime fecha;

		Console.Write ("Ingrese dia de Nacimiento: ");
		dia = Console.ReadLine ();
		Console.Write ("\nIngrese mes de Nacimiento: ");
		mes = Console.ReadLine ();
		Console.Write ("\nIngrese año de Nacimiento: ");
		anio = Console.ReadLine ();

		if (int.TryParse(anio,out comprobacion) && int.TryParse (mes, out comprobacion)
			&& int.TryParse (dia, out comprobacion)) {
			
			string fNacimiento = string.Format ("{0}/{1}/{2}", dia, mes, anio);
			if (DateTime.TryParse (fNacimiento, out fecha)) {
				TimeSpan diasDeVida = DateTime.Now - fecha;

				Console.WriteLine ("usted a vivido "+String.Format("{0:n}",diasDeVida.Days) + " dias desde " + fecha.ToShortDateString()+
					" hasta " + DateTime.Now.ToShortDateString());
				Console.ReadLine();
			} else {
				Console.WriteLine ("ERROR la fecha {0} que ingreso no es valida!",fNacimiento);
				Console.WriteLine ("¿desea ingresar la fecha de nuevo? yes/no");
			    opcion = Console.ReadLine ();
				if (opcion == "yes" || opcion == "y") {
					diasFechaNacimiento ();
				} 
			}
			
		} else {

			Console.WriteLine ("ERROR en el formato ingresado: ¿desea ingresar la fecha de nuevo? yes/no");
			opcion = Console.ReadLine ();
			if (opcion == "yes" || opcion == "y") {
				diasFechaNacimiento ();
			} 
		}	
	}
	
}//final clase
