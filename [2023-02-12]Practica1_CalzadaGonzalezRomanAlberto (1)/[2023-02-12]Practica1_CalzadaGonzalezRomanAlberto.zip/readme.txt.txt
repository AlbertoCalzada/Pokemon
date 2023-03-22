Nombre: Alberto Calzada González-Román.

Observaciones:

El juego por defecto está con el constructor que inicia el juego en modo lento, si se desea cambiar a modo rápido bastaria con modificar del Main:

	IO io = new IO();
        Game g = new Game(io);
        g.Run();
a
	IO io = new IO();
        Game g = new Game();
        g.Run();

Ya que esta establecido que el modo rápido sea el que no recibe ningún parámetro de entrada.


