const urlCategorias = "http://localhost:5195/Categories";
const urlSites = "http://localhost:5195/Sites";

recogerDatosCategorias();
function recogerDatosCategorias(){
fetch(urlCategorias)
.then(response => response.json())
.then(jsonCategorias => mostrarDatosCategorias(jsonCategorias))
.catch(error => console.error(error));
}

function mostrarDatosCategorias(datos){
datos.forEach((resultado) => mostrarCategorias(resultado))
}

function mostrarCategorias(dato){
let resultados = document.getElementById("resultados");
let div = document.createElement("div");
let pre = document.createElement("pre");
pre.innerHTML = JSON.stringify(dato.nombre);

div.appendChild(pre);
resultados.appendChild(div);
}

recogerDatosSites();
function recogerDatosSites(){
fetch(urlSites)
.then(response => response.json())
.then(jsonCategorias => mostrarDatosSites(jsonCategorias))
.catch(error => console.error(error));
}

function mostrarDatosSites(datos){
datos.forEach((resultado) => mostrarSites(resultado))
}

function mostrarSites(dato){
let resultados = document.getElementById("resultadosSites");
let div = document.createElement("div");
let pre = document.createElement("pre");
let botonBorrar = document.createElement("button");
pre.innerHTML = JSON.stringify(dato.nombre) + " - " + JSON.stringify(dato.description) ;
botonBorrar.innerHTML = "Eliminar " + JSON.stringify(dato.nombre);
div.appendChild(pre);
div.appendChild(botonBorrar);
resultados.appendChild(div);
}

function crearCategoria(){
   const data = new FormData(document.getElementById('formularioCategoria'));
  // var data = document.getElementById('nombreCategoriaCrear');
    fetch(urlCategorias, {
       method: 'POST',
       body: data
    })
    .then(function(response) {
       if(response.ok) {
        console.log("si");
           return response.text()
       } else {
           throw "Error en la llamada Ajax";
       }    
    })
    .then(function(texto) {
       console.log(texto);
    })
    .catch(function(err) {
       console.log(err);
    });
}