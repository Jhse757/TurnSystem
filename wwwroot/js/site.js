
function recibir() {
    let numero_documento = document.getElementById("numero_documento").value;
    let numero_documento2 = document.getElementById("numero_documento2");

    numero_documento2.value = numero_documento;
}

function agregarNumero(numero) {
    var txtNumero = document.getElementById("numero_documento");
    txtNumero.value += numero;
    recibir(); 
}

function NumberDelete() {
    var txtNumero = document.getElementById("numero_documento");
    txtNumero.value = "";
    recibir(); 
}
