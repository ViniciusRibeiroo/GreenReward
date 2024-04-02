<template>
  <b-row class="vh-100 vw-100 row-login">
    <b-col sm="7" class="d-flex justify-content-center align-items-center container-background">
      <img src="../assets/home.png" class="img-login" />
    </b-col>
    <b-col sm="5" class="d-flex justify-content-center align-items-center">
      <div class="col-8">
        <h2 class="text-center titulo">Fazer login</h2>

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
            <b-icon icon="arrow-bar-right" style="width: 15px;"></b-icon> ENTRAR
          </b-button>
        </div>
        <div class="container-botao">
          <p
          class="subtitulo"
          style="cursor: pointer;text-decoration: underline;"
          @click="CreateAccount"
          >
          CADASTRE-SE
        </p>
        </div>

      </div>
    </b-col>
  </b-row>
</template>

<script>

export default {
  data () {
    return {
      form: {
        email: '',
        password: ''
      }
    }
  },
  methods: {
    CreateAccount () {
      this.$router.push('/create-account')
    },
    back () {
      this.$router.push('/')
    }
  }
}
</script>

<style>
*,
*::after,
*::before {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  text-decoration: none;
}
.row-login {
  margin-left: 0;
}
.img-login {
  width: 500px;
}
.container-background {
  background: linear-gradient(to bottom, #ffffff, #d2d2d2);
  min-height: calc(87.3vh - 20px);
  padding-bottom: 5px;
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
  width: 80%;
  border-width: 0.215rem;
  border-color: black;
  border-radius: 30px;
}
</style>
