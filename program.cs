using System;

class Programa{

	public static void Main(string[] args){
		Programa.crearMenu("Titulo prueba aplicación","Autor: Akira94");	
	}

	private static void crearMenu(string titulo, string autor){
		int opcion = 0; 
		
		Console.Clear();
		do {			
			dibujarMenu(20, 1, 60, 15);
			dibujarMenu (20, 17, 60, 19);
			escribirMensaje(((20+60)/2)-autor.Length/2,18,autor);
			escribirMensaje(((20+60)/2)-titulo.Length/2,2,titulo);
			escribirMensaje(21, 4, "1. cantidad de dias vividos");
			escribirMensaje(21,5,"2. numero decimal a binario");
			escribirMensaje(21,6,"3. determinar si un numero es primo");
			escribirMensaje(21,7,"4. determinar el tipo de un triangulo");
			escribirMensaje(21,14,"0. salir de la aplicación: ");
			//Console.WriteLine("Opcion="+opcion);
			if(int.TryParse(Console.ReadLine (),out opcion)){
				switch (opcion){
					case 1:
						Console.Clear();
						diasFechaNacimiento();	
						Console.Clear();
						break;
					case 2:
						Console.Clear();
						numeroAbinario();
						Console.Clear();
						break;	
					case 3:
						Console.Clear();
						esNumeroPrimo();
						Console.Clear();
						break;
					case 4:
						Console.Clear();
						determinarTipoTriangulo();
						Console.Clear();
						break;
					case 0:
						Console.Clear();
						break;
				}
			}
		}while(opcion != 0);
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

	//método para determinar si un triangulo es equilatero, isósceles o escaleno
	public static void determinarTipoTriangulo(){
		int lado;
		string opcion;
		int[] lados = new int[3];
		bool[] valores = new bool[3];  

		for (int i = 0;i <= lados.Length-1; i++) {
			lado = i + 1;
			Console.Write("Ingrese el valor del lado{0}: ",lado);
			valores [i] = int.TryParse (Console.ReadLine (), out lados [i]); 
		}

		if (valores [0] && valores [1] && valores [2]) {
			Console.WriteLine ("valor lado1: {0} lado2: {1} lado3: {2}", lados [0], lados [1], lados [2]);
			
			if (lados [0] == lados [1] && lados [0] == lados [2] && lados[1] == lados[2]) {
				Console.WriteLine ("Todos sus lados son iguales, el triangulo es EQUILATERO");
			}else if(lados[0] != lados[1] && lados[0] != lados[2] && lados[1] != lados[2]){
				Console.WriteLine ("Todos sus lados son diferentes, el triangulo es ESCALENO");
			}else if((lados[0] == lados[1] && lados[0] != lados[2]) || (lados[0] != lados[1] && 
				lados[0] == lados[2]) || (lados[1] == lados[2] && lados[0] != lados[1]) ||
				(lados[1] == lados[2] && lados[0] != lados[2])){
				Console.WriteLine ("Dos lados son iguales y uno diferente, el triangulo es ISÓSCELES");
				}
			Console.ReadLine ();

		} else {
			Console.WriteLine ("¡ERROR los valores ingresados de los lados no son validos! ¿desea ingresar un nuevo los valores? yes/no");
			opcion = Console.ReadLine ();
			if (opcion == "yes" || opcion == "y") {
				determinarTipoTriangulo ();
			}
		}
	}	
	
	//método intercambiar orden de valores
	public static void cambiaContraseña(){

		int password = 0;
		string pass = "", temporal = "";
		string opcion = "no"; 

		Console.Write ("Ingrese una contraseña que solo consista de digitos y con una longitud de 4 digitos: ");
		if (int.TryParse (Console.ReadLine (), out password)) {
			temporal = Convert.ToString(password);
			if (temporal.Length == 4) {
				for (int i = temporal.Length-1; i >= 0; i--) {
					pass += temporal [i];
				}
				password = int.Parse (pass);
				Console.WriteLine ("La contraseña ingresda por usted es: {0} se enviará como: {1}",temporal,password);
				Console.ReadLine ();
			} else {
				Console.Write ("ERROR la conraseña no tiene una longitud exacta a 4, ¿desea volver a ingresar la contraseña? yes/no: ");	
				opcion = Console.ReadLine ();
				if (opcion == "yes" || opcion == "y") {
					cambiaContraseña ();
				}
			}
		} else {
			Console.Write ("ERROR la contraseña ingresada no consiste de digitos, ¿desea volver a ingresar otra contraseña? yes/no: ");
			opcion = Console.ReadLine ();
			if (opcion == "yes" || opcion == "y") {
				cambiaContraseña ();
			}
		}
	}

	//método para determinar si un numero es capicua
	public static void numeroCapicua(){

		string valorIngresado,opcion;
		string primerosDigitos, segundosDigitos;
		int numero, mitad, longitud;
		bool falso = false;

		Console.Write ("Ingrese un numero (solo digitos): ");
		if (int.TryParse (valorIngresado = Console.ReadLine (), out numero)) {

			mitad = valorIngresado.Length / 2;

			if (valorIngresado.Length % 2 == 0) {

				//Console.WriteLine (mitad);
				//Console.WriteLine (valorIngresado.Length - 1);
				primerosDigitos = valorIngresado.Substring (0,mitad);
				segundosDigitos = valorIngresado.Substring (mitad, mitad);
				//Console.Write ("primero digitos: {0}",primerosDigitos);
				//Console.Write ("segundos digitos: {0}",segundosDigitos);

				//Console.WriteLine (primerosDigitos.Length + " " + segundosDigitos.Length);

				/*
				for (int i = 0; i < valorIngresado.Length; i++) {
					Console.WriteLine ("Indice {0}: {1}", i, valorIngresado[i]);
				}
				*/
				longitud = mitad -1;

				for (int indice = 0; indice < mitad; indice++) {
					if (primerosDigitos [indice] != segundosDigitos [longitud]) {
						falso = true;
						break;
					} //else {
						//Console.WriteLine ("primerosDigitos digito indice {0}: {1} / SegundosDigitos digito indice {2}: {3}",
							//indice,primerosDigitos[indice],longitud,segundosDigitos[longitud]);
					//} 
					longitud--;
				}
				//Console.WriteLine (falso);

				if (falso) {
					Console.WriteLine ("El numero {0} NO es capicua",numero);
				} else {
					Console.WriteLine ("El numero {0} es capicua",numero);
				}

				Console.ReadLine ();
			} else if (valorIngresado.Length % 2 != 0) {

				//Console.WriteLine (mitad);

				primerosDigitos = valorIngresado.Substring (0,mitad);
				segundosDigitos = valorIngresado.Substring (mitad+1, mitad);
				//Console.Write ("primero digitos: {0}",primerosDigitos);
				//Console.Write ("segundos digitos: {0}",segundosDigitos);

				longitud = mitad -1;

				for (int indice = 0; indice < mitad; indice++) {
					if (primerosDigitos [indice] != segundosDigitos [longitud]) {
						falso = true;
						break;
					} //else {
						//Console.WriteLine ("primerosDigitos digito indice {0}: {1} / SegundosDigitos digito indice {2}: {3}",
							//indice,primerosDigitos[indice],longitud,segundosDigitos[longitud]);
					//} 
					longitud--;
				}

				if (falso) {
					Console.WriteLine ("El numero {0} NO es capicua",numero);
				} else {
					Console.WriteLine ("El numero {0} es capicua",numero);
				}

				Console.ReadLine ();
			}
		} else {
			Console.Write ("ERROR el valor ingresado no corresponde a un numero, ¿desea volver a ingresar otro numero? yes/no: ");
			opcion = Console.ReadLine ();
			if (opcion == "yes" || opcion == "y") {
				cambiaContraseña ();
			}
		}


	}

}//final clase
