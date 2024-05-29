<template>
  <div class="container-background">

    <div class="container-banner">
      <h1 class="titulo">Cadastro</h1>
    </div>

    <b-form
      ref="form"
      class="container-input"
      >
      <b-form-input
        v-model="name"
        autocomplete="off"
        placeholder="*NOME"
        type="text"
        class="input"
        :state="nameState"
        required
      ></b-form-input>
    </b-form>
    <div class="container-input">
      <b-form-input
        v-model="cpf"
        autocomplete="off"
        v-mask="'###.###.###-##'"
        placeholder="*CPF"
        class="input"
        :state="cpfState"
        required
        @input="checkCPF"
        @blur="cpfBlur"
        @focus="cpfFocus"
      ></b-form-input>
    </div>
    <p
      v-if="!cpfValido && cpfTocado"
      style="color: red;font-weight: bold;display: flex;justify-content: center;align-items: center;"
    >
      <b-icon icon="exclamation-circle" style="width: 15px;margin-right: 6px;"></b-icon>
      Insira um CPF válido.
    </p>
    <div class="container-input">
      <b-form-input
        v-model="email"
        autocomplete="off"
        placeholder="*E-MAIL"
        type="text"
        class="input"
        :state="emailState"
        required
        @input="checkEmail"
        @blur="emailBlur"
        @focus="emailFocus"
      ></b-form-input>
    </div>

    <p
      v-if="!emailValido && emailTocado"
      style="color: red;font-weight: bold;display: flex;justify-content: center;align-items: center;"
    >
      <b-icon icon="exclamation-circle" style="width: 15px;margin-right: 6px;"></b-icon>
      Insira um e-mail válido.
    </p>

    <div class="container-input">
      <b-form-input
        v-model="senha"
        autocomplete="off"
        placeholder="*SENHA"
        type="password"
        name="password"
        id="password"
        class="input"
        :state="passState"
        required
      >
    </b-form-input>
    </div>

    <p
      v-if="!formIsValid"
      style="font-weight: bold;display: flex;justify-content: center;align-items: center;"
    >
      <b-icon icon="exclamation-circle" style="width: 15px;margin-right: 6px;"></b-icon>
      Preencha os campos obrigatórios.
    </p>

    <div class="container-botao">
      <b-button
        class="botao"
        @click="home"
      >
        <b-icon icon="house" style="width: 15px;"></b-icon> HOME
      </b-button>
      <b-button
        class="botao"
        @click="back"
      >
        <b-icon icon="arrow90deg-left" style="width: 15px;"></b-icon> VOLTAR
      </b-button>
      <b-button
        class="botao"
        type="submit"
        :disabled="!formIsValid"
        @click="postUser"
      >
        <b-icon icon="arrow-bar-right" style="width: 15px;"></b-icon> CADASTRAR
      </b-button>
    </div>

  </div>
</template>

<script>
import {
  BFormInput, BForm, BButton
} from 'bootstrap-vue'
import axios from 'axios'

export default {
  components: {
    BForm,
    BButton,
    BFormInput
  },
  data () {
    return {
      name: '',
      cpf: '',
      email: '',
      senha: '',
      emailTocado: false,
      cpfTocado: false
    }
  },
  computed: {
    nameState () {
      return this.name ? true : null
    },
    cpfState () {
      return this.checkCPF(this.cpf) ? true : null
    },
    cpfValido () {
      return this.checkCPF(this.cpf)
    },
    emailState () {
      return this.checkEmail(this.email) ? true : null
    },
    emailValido () {
      return this.checkEmail(this.email)
    },
    passState () {
      return this.senha ? true : null
    },
    formIsValid () {
      return (
        this.name &&
        this.checkCPF(this.cpf) &&
        this.checkEmail(this.email) &&
        this.senha
      )
    }
  },
  methods: {
    back () {
      this.$router.push('/login')
    },
    home () {
      this.$router.push('/')
    },
    clearForm () {
      this.name = ''
      this.cpf = ''
      this.email = ''
      this.senha = ''
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
    checkCPF (cpf) {
      const re = /^\d{3}\.\d{3}\.\d{3}-\d{2}$/
      return re.test(cpf)
    },
    cpfBlur () {
      this.cpfTocado = true
    },
    cpfFocus () {
      this.cpfTocado = false
    },
    postUser () {
      if (this.formIsValid && this.$refs.form.checkValidity()) {
        if (this.checkEmail(this.email) && this.checkCPF(this.cpf)) {
          const DATA = [
            this.name,
            this.cpf,
            this.email,
            this.senha
          ]
          axios
            .post('http://localhost:8080/api/User', {
              data: DATA,
              name: this.name,
              cpf: this.cpf,
              email: this.email,
              senha: this.senha
            })
            .then(response => {
              console.log(response)
              this.clearForm()
              this.cpfTocado = false
              this.emailTocado = false
              // eslint-disable-next-line no-undef
              Toast.fire('Usuário cadastrado!', 'Agora você pode realizar o login na aplicação.', 'success')
            })
            .catch(error => {
              console.error('Erro ao cadastrar usuário:', error)
              // eslint-disable-next-line no-undef
              Toast.fire('Erro!', 'Ocorreu um erro.', 'error')
            })
        }
      }
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
