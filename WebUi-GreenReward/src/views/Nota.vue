<template>
  <div class="container-background">
    <h1 class="titulo conteudo">NOTA FISCAL</h1>
    <h1 class="subsubtitulo conteudo">Sorocaba, 03 de Fevereiro de 2023</h1>
    <h1 class="subsubtitulo conteudo">Prefeitura de Sorocaba</h1>

    <div style="margin-top: 3rem;">
      <h2 class="subsubtitulo conteudo-central">Valor: R$12,29</h2>
      <h2 class="subsubtitulo conteudo-central">Material: Papelão</h2>
      <h2 class="subsubtitulo conteudo-central">Quantidade: 500g</h2>
      <h2 class="subsubtitulo conteudo-central">CPF: 123.456.789-99</h2>
    </div>

    <div style="margin-top: 2rem;">
      <h5 class="subsubtitulo conteudo">Compra realizada no valor de R$12,29 sobre a quantia de</h5>
      <h5 class="subsubtitulo conteudo">500g de *Material*, para Roberto cadastrado no CPF 123.456.789-99.</h5>
    </div>
  </div>
</template>

<style scoped>
.container-background {
  min-height: 100vh;
  padding-bottom: 5px;
}
.conteudo {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 2%;
}
.conteudo-central {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 2%;
}
.subsubtitulo {
  margin-top: 0;
}
</style>
