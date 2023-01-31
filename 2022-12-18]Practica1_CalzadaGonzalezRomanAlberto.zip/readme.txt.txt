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
El archivo esta realizado con la misma versión que en clase, por lo que una versión superior puede dar problemas a la hora de ejecutarlo, ya que en mi ordenador
el Framework era superior y tuve que poner el mismo que en clase: .NET Core 3.1.

