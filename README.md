# Inventario API REST
Esta API fue realizada en Visual Studio 2017 y para el test PostMan.
Por falta de tiempo solo he implementado un controlador(HomeController) y el modelo de datos(Products).
Para obtener los datos he utilizado LINQ-to-Entities.
En WebApiConfig.cs he configurado el mapa de rutas como:
          config.Routes.MapHttpRoute(
                ************
                routeTemplate: "api/{controller}/{action}/{id}",
                ***************
            );
Consta de los siguientes métodos:
1-Obtener todos los productos del inventario
  GET api/Home/
2-Obtener los detalles de un producto determinado
   GET api/Home/2 
3-Obtener el nombre de los productos caducados
  GET api/Home/GetCaducados
4-Adicionar un elemento al inventario
  POST api/Home
5-Actualizar algunos datos de un producto determinado
  PUT api/Home/
6-Sacar el elemento del inventario sin ser eliminado(posu ID), modificando su campo 'baja'
  PATCH api/Home/2
7-Eliminar un elemento del inventario
  DELETE api/Home/4
  
Seguridad: No está implementada pero considero que utilizando JSON Web Token(JWT) con la identidad del cliente y su firma accederían o no al invemntario,
la idea es que también los clientes una vez ya dentro de la api tengan diferentes permisos, es decir unos tengan acceso total(CRUD), otros tengan solo acceso a dar de alta a productos y otros solo a obtener información de los productos del inventario.
 JWT="header.payload.firma" ,esto se puede generar y enviar a cada usuario.


  
 
