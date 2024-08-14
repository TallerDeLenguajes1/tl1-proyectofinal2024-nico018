# Harry Potter Battle Arena

## Descripción del Juego

Harry Potter Battle Arena es un juego de simulación de combate donde los jugadores eligen personajes del universo de Harry Potter para que compitan entre ellos. El juego se desarrolla por turnos, y cada combate continúa hasta que uno de los personajes es derrotado (es decir, su salud llega a 0). El personaje ganador avanza y se enfrenta a otros personajes hasta que solo uno queda en pie. El último personaje en pie es declarado el ganador y merecedor del Calix de Fuego.

## Temática

El juego está ambientado en el mundo mágico de Harry Potter. Los personajes disponibles para elegir son Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Draco Malfoy, Luna Lovegood, Sirius Black. Cada personaje tiene habilidades únicas y atributos que se utilizan durante los combates.

## Archivos `.cs` y su Funcionalidad

### `Program.cs`

Este es el archivo principal que orquesta el flujo del juego. Sus funciones incluyen:
- Solicitar el nombre del usuario y permitir la elección del personaje.
- Crear los personajes con sus habilidades.
- Gestionar la secuencia de combates entre los personajes.
- Mostrar los resultados de cada combate y declarar al ganador final.
- Guardar y leer el historial de ganadores.


### `Personaje.cs`

Define la estructura de los personajes, con propiedades para:
- Nombre
- Varita
- Magia
- Nivel
- Efectividad
- Hechizo de Defensa
- Reflejos
- Salud

### `Combatir`
Gestiona el proceso de combate entre dos personajes.
- Método IniciarCombate: Este método maneja la lógica principal del combate, donde dos personajes se enfrentan. Dentro de este método, se realizan ataques entre los personajes hasta que uno de ellos pierde toda su salud. Utiliza la clase CalcularDanio para determinar el daño infligido en cada ataque.

### `CalcularDanio` 
-Calcula el daño que un personaje inflige a otro durante el combate.
- Método Calcular(): Este método toma en cuenta varios factores como la fuerza del atacante, la defensa del oponente y otros modificadores para calcular el daño neto que será infligido. Este cálculo es importante para determinar el resultado de cada ataque en el combate.

### `MejorarHabilidades` 
Mejora las habilidades de un personaje después de un combate.
- Método Mejorar(): Este método se utiliza para incrementar los atributos de un personaje, como fuerza, defensa, y otros, basándose en su desempeño durante el combate. Es una manera de reflejar el crecimiento y desarrollo del personaje a medida que participa en más combates.

### `ApiPersonaje` 
Gestiona la comunicación con la API externa para obtener información de los personajes.
- Método ObtenerPersonaje(string nombre): Este método se encarga de realizar una solicitud a la API externa utilizando el nombre del personaje como parámetro. Si la API responde correctamente, devuelve los datos del personaje, como sus estadísticas y habilidades. Si la API no responde o hay un error, el método puede manejar la situación devolviendo un valor nulo o un mensaje de error, lo que permite al programa continuar utilizando los personajes guardados localmente en un archivo JSON.

### `LeerGanadores`
Esta clase está diseñada para leer y procesar los datos de los ganadores almacenados en un archivo JSON.
- Métodos principales: Leer(): Este método abre el archivo JSON que contiene los ganadores de combates anteriores y deserializa el contenido en una lista de objetos o un formato similar que la aplicación puede usar. Esto permite que los ganadores anteriores sean cargados y posiblemente mostrados o analizados dentro del programa 

### `GuardarGanador` 
Esta clase maneja la escritura de nuevos ganadores en el archivo JSON.
- Métodos principales: Guardar(Personaje ganador): Este método toma el objeto Personaje que ha ganado un combate y lo agrega al archivo JSON que almacena todos los ganadores. Esto se hace deserializando el contenido actual del archivo, agregando el nuevo ganador a la lista, y luego serializando nuevamente todo el contenido en el archivo.

### `Registro` 
Administra el registro de nombre, informacion y fecha para ocuparlos mas adelante en otros metodos

## Sistema de Combate

El sistema de combate se basa en turnos, donde los personajes alternan entre atacar y defender. La fórmula para calcular el daño provocado en cada turno es la siguiente:

### Fórmulas

#### Ataque

Ataque = magia + Varita + Nivel

- **Magia**: Potencia mágica del personaje. (Valor entre 10 y 50)
- **Varita**: Varita mágica del personaje. (Valor entre 1 y 10)
- **Nivel**: Nivel mágico del personaje. (Valor entre 1 y 20)

#### Defensa

Defensa = Hechizo de Defensa + Reflejos + efectividad


- **Hechizo de Defensa**: Calidad del hechizo defensivo. (Valor entre 20 y 100)
- **Reflejos**: Velocidad y capacidad de reacción del personaje. (Valor entre 1 y 10)
- **efectividad**: efectividad de ataque del personaje. (Valor entre 10 y 100)


### Actualización de la Salud

Salud = Salud - Daño Provocado
- El personaje cuya salud llega a 0 es derrotado, y el ganador obtiene una mejora en sus habilidades como salud, magia y nivel. Este proceso continúa hasta que solo queda un personaje en pie, que es declarado el ganador final.

## APIs Utilizadas
### `HarryPotterAPI.cs`

### API de Personajes de Harry Potter

- **URL**: `https://hp-api.onrender.com/api/characters`
- **Uso**: La API se utiliza en el archivo `Program.cs` dentro del método `MostrarDatosAdicionales` para obtener y mostrar datos adicionales del personaje elegido por el usuario. Esta información incluye detalles como la casa, fecha de nacimiento, ascendencia y patronus del personaje.
