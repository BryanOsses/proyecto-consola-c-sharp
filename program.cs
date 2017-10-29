using System;

class Programa{

	public static void Main(string[] args){
		Programa.crearMenu("Titulo prueba aplicación","Autor: Akira94");	
	}

	private static void crearMenu(string titulo, string autor){
		
	}

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
}
