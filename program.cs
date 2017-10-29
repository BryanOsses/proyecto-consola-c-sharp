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

	//método para convertir en binario un numero decimal de 8 bits
	public static void numeroAbinario(){

		string opcion;
		byte numero = 0;
		string binario = "",temporal="";
		byte modulo;

		Console.Write ("Ingrese un valor entero entre 0 y 255: ");

		if(byte.TryParse(Console.ReadLine (),out numero)){
			do {
				modulo = (byte)(numero % 2);
				temporal += modulo;
				numero = (byte)(numero/2);
			} while(numero >= 1);


			for (int i = temporal.Length-1; i >= 0; i--) {
				binario += temporal [i];
			}

			Console.WriteLine("en binario: {0}",binario);
			Console.ReadLine ();	
		}else{
			Console.WriteLine ("¡ERROR el valor ingresado no es valido! ¿desea ingresar un nuevo valor? yes/no");
			opcion = Console.ReadLine ();
			if (opcion == "yes" || opcion == "y") {
				numeroAbinario ();
			}
		}
	}
	
	//método para determinar si un numero es primo
	public static void esNumeroPrimo(){

		int numero,divisores=0;
		string opcion;

		Console.Write ("Ingrese el valor a evaluar: ");
		if (int.TryParse (Console.ReadLine (), out numero)) {

			for (int i = 1; i <= numero; i++) {
				if (numero % i == 0) {
					divisores++;
				}
			}

			if (divisores == 2) {
				Console.WriteLine ("el numero {0} es primo",numero);
			} else {
				Console.WriteLine ("el numero {0} NO es primo",numero);
			}
			Console.ReadLine ();
		} else {
			Console.WriteLine ("¡ERROR el valor ingresado no es valido! ¿desea ingresar un nuevo valor? yes/no");
			opcion = Console.ReadLine ();
			if (opcion == "yes" || opcion == "y") {
				numeroAbinario ();
			}
		}
	}

}//final clase
