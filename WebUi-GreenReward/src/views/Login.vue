<template>
  <b-row class="vh-100 vw-100 row-login">
    <b-col sm="7" class="d-flex justify-content-center align-items-center container-background">
      <img src="../assets/home.png" class="img-login" />
    </b-col>
    <b-col sm="5" class="d-flex justify-content-center align-items-center">
      <div class="col-8">
        <h2 class="text-center titulo">Fazer login</h2>

        <div class="container-input">
          <b-form-input
            id="email"
            type="email"
            class="input"
            autocomplete="off"
            placeholder="E-MAIL"
            v-model="email"
            @blur="emailBlur"
            @focus="emailFocus"
            ></b-form-input>
        </div>
        <div class="container-input">
          <b-form-input
            id="senha"
            type="password"
            class="input"
            placeholder="SENHA"
            v-model="senha"
            ></b-form-input>
        </div>

        <div class="container-botao">
          <b-button class="botao" @click="back">
            <b-icon icon="arrow90deg-left" style="width: 15px;"></b-icon> VOLTAR
          </b-button>
          <b-button
            class="botao"
            type="submit"
            block
            @click="submit"
            >
            <b-icon icon="arrow-bar-right" style="width: 15px;"></b-icon> ENTRAR
          </b-button>
        </div>

        <p
          v-if="error"
          style="color: red;font-weight: bold;display: flex;justify-content: center;align-items: center; margin-top: 12px;"
        >
          <b-icon icon="exclamation-circle" style="width: 15px;margin-right: 6px;"></b-icon>
          {{ error }}
        </p>

        <div class="container-botao">
          <p
          class="subtitulo"
          style="cursor: pointer;text-decoration: underline;"
          @click="CreateAccount"
          >
          CADASTRE-SE
        </p>
        </div>
        <div class="text-center">
          <p
          class="subtitulo"
          style="cursor: pointer;text-decoration: underline; font-size: 22px; font-weight: bold"
          v-b-modal.modal-center
          >
          ESQUECI MINHA SENHA
        </p>
        <b-modal
          id="modal-center"
          ref="modal"
          centered
          title="Submit Your Name"
          hide-header
          @show="resetModal"
          @hidden="resetModal"
          @ok="handleOk"
        >
          <h5>Adicione um e-mail de recuperação para redefinir sua senha</h5>
          <form ref="form" @submit.stop.prevent="handleSubmit">
            <b-form-group
              label="Email:"
              label-for="name-input"
              invalid-feedback="Name is required"
            >
              <b-form-input
                id="name-input"
                required
              ></b-form-input>
            </b-form-group>
          </form>
          <template #modal-footer="{ ok }">
            <b-button class="botao" v-on="ok">ENVIAR</b-button>
          </template>
        </b-modal>
        </div>

      </div>
    </b-col>
  </b-row>
</template>

<script>
import axios from 'axios'

export default {
  data () {
    return {
      email: '',
      senha: '',
      error: '',
      emailTocado: false
    }
  },
  computed: {
    emailValido () {
      return this.checkEmail(this.email)
    }
  },
  methods: {
    CreateAccount () {
      this.$router.push('/create-account')
    },
    back () {
      this.$router.push('/')
    },
    checkEmail () {
      const re = /\S+@\S+\.\S+/
      return re.test(this.email)
    },
    emailBlur () {
      this.emailTocado = true
    },
    emailFocus () {
      this.emailTocado = false
    },
    async submit () {
      if (!this.email || !this.senha) {
        this.error = 'Preencha os campos obrigatórios.'
        return
      }
      if (!this.checkEmail(this.email)) {
        this.error = 'Insira um email válido.'
        return
      }
      const loginData = {
        email: this.email,
        senha: this.senha
      }
      axios
        .post('http://localhost:8080/api/User/login', loginData)
        .then((response) => {
          this.$router.push('/menu')
          console.log(response.data)
        })
        .catch((error) => {
          this.error = 'Login ou senha incorretos'
          console.error('Erro ao fazer login', error)
        })
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
  background: linear-gradient(to bottom, #ffffff, #d0d0d0);
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
