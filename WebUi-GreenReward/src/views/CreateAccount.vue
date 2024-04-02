<template>
  <div class="container-background">
    <div class="container-banner">
      <h1 class="titulo">Cadastro</h1>
    </div>
    <div class="container-input">
      <b-form-input class="input" placeholder="NOME"></b-form-input>
    </div>
    <div class="container-input">
      <b-form-input class="input" placeholder="CPF"></b-form-input>
    </div>
    <div class="container-input">
      <b-form-input class="input" placeholder="E-MAIL"></b-form-input>
    </div>
    <div class="container-input">
      <b-form-input class="input" placeholder="SENHA"></b-form-input>
    </div>
    <div class="container-botao">
      <b-button class="botao" @click="back">
        <b-icon icon="arrow90deg-left" style="width: 15px;"></b-icon> VOLTAR
      </b-button>
      <b-button class="botao" @click="login">
        <b-icon icon="arrow-bar-right" style="width: 15px;"></b-icon> CADASTRAR
      </b-button>
    </div>
  </div>
  <!-- <b-button class="botao">
    CADASTRAR
  </b-button>
  <b-button class="botao" @click="back">
    VOLTAR
  </b-button> -->
</template>

<script>
export default {
  methods: {
    back () {
      this.$router.push('/login')
    }
  }
}
</script>

<style scoped>
.container-background {
  background: linear-gradient(to bottom, #ffffff, #d2d2d2);
  min-height: calc(93vh - 20px);
  padding-bottom: 5px;
}
.container-banner {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 10vh;
}
.container-input {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 3vh;
  margin-bottom: 3vh;
}
.container-botao {
  margin-top: 4vh;
  display: flex;
  justify-content: center;
  align-items: center;
}
.botao {
  background-color: #062800;
  padding: 10px 20px;
  border: 2px solid #062800;
  color: white;
  font-size: 16px;
  border-radius: 40px;
  font-weight: bold;
  margin-right: 1rem;
}
.input {
  width: 25%;
  border-width: 0.215rem;
  border-color: black;
  border-radius: 30px;
}
</style>
