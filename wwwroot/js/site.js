function Paginacao(page){
    console.log("Page " + page);

    var currentPage = document.getElementById("currentPage");
    console.log("CurrentPage " + currentPage.value);
    var maxPage = document.getElementById("maxPage");
    console.log("MaxPage " + maxPage.value);

    var tabelaAtiva = document.getElementById("table-" + currentPage.value);
    var ativarTabela = document.getElementById("table-" + page);
    var pageItem = document.getElementsByClassName("page-item");

    if(page > 0){
        document.getElementById("prev").classList.remove("disabled")
    }
    else{
        document.getElementById("prev").classList.add("disabled")
    }

    if(page < parseInt(maxPage.value) - 1){
        document.getElementById("next").classList.remove("disabled")
    }
    else{
        document.getElementById("next").classList.add("disabled")
    }

    tabelaAtiva.style.display = "none";

    ativarTabela.style.display = "";

    
    if(pageItem !== null){
        pageItem[page + 1].classList.add("active");
        pageItem[parseInt(currentPage.value) + 1].classList.remove("active");
    }
    
    currentPage.value = page;

    console.log("CurrentPage " + currentPage.value);

}

function MudarPagina(mudar){
    var currentPage = parseInt(document.getElementById("currentPage").value);

    Paginacao(currentPage + mudar);
}