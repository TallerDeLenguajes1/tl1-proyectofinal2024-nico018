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

### `HabilidadesDePersonajes.cs`

Esta clase se encarga de generar las habilidades y atributos de los personajes. Utiliza valores aleatorios para asignar:
- Magia
- Varita
- Nivel
- Efectividad
- Hechizo de Defensa
- Reflejos
- Salud

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

### `PersonajesJson.cs`

Esta clase contiene métodos para:
- Guardar los personajes en un archivo JSON.
- Leer los personajes desde un archivo JSON.
- Verificar si un archivo JSON existe y contiene datos.

### `HistorialJson.cs`

Esta clase maneja el historial de ganadores, con métodos para:
- Guardar el ganador de cada combate en un archivo JSON.
- Leer la lista de ganadores desde un archivo JSON.
- Verificar si el archivo de historial existe y contiene datos.

## Sistema de Combate

El sistema de combate se basa en turnos, donde los personajes alternan entre atacar y defender. La fórmula para calcular el daño provocado en cada turno es la siguiente:

### Fórmulas

#### Ataque

Ataque = Magia * Varita * Nivel


- **Magia**: Potencia mágica del personaje.
- **Varita**: Calidad de la varita (valor entre 1 y 10).
- **Nivel**: Nivel de habilidad del personaje en magia (valor entre 1 y 100).

#### Defensa

Defensa = Hechizo de Defensa * Reflejos


- **Hechizo de Defensa**: Calidad del hechizo defensivo.
- **Reflejos**: Velocidad y capacidad de reacción del personaje.

#### Daño Provocado

Daño Provocado = ((Ataque * Efectividad) - Defensa) / 500


- **Efectividad**: Valor aleatorio entre 1 y 100.
- **Constante de Ajuste**: 500, utilizada para balancear el juego.

### Actualización de la Salud

Salud = Salud - Daño Provocado


El personaje cuya salud llega a 0 es derrotado, y el ganador obtiene una mejora en sus habilidades (+10 en salud o +5 en defensa). Este proceso continúa hasta que solo queda un personaje en pie, que es declarado el ganador final.

## APIs Utilizadas
### `HarryPotterAPI.cs`

### API de Personajes de Harry Potter

- **URL**: `https://hp-api.onrender.com/api/characters`
- **Uso**: La API se utiliza en el archivo `Program.cs` dentro del método `MostrarDatosAdicionales` para obtener y mostrar datos adicionales del personaje elegido por el usuario. Esta información incluye detalles como la casa, fecha de nacimiento, ascendencia y patronus del personaje.
