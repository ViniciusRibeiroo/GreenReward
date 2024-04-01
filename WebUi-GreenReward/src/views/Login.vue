<template>
  <b-row class="vh-100 vw-100 row-login">
    <b-col sm="7" class="d-flex justify-content-center align-items-center container-background">
      <img src="../assets/home.png" class="img-login" />
    </b-col>
    <b-col sm="5" class="d-flex justify-content-center align-items-center">
      <div class="col-8">
        <h2 class="text-center mb-5 title-login">Faça o login</h2>

        <b-form>
          <b-form-group
            label="E-mail"
            label-for="email"
            >
              <b-form-input
                id="email"
                type="email"
                placeholder="joaosilva@email.com"
                autocomplete="off"
              ></b-form-input>
            </b-form-group>

            <b-form-group
              label-for="password"
            >
              <label class="d-flex justify-content-between">
                  Senha
                <small><a href="#" v-b-modal.modal-prevent-closing>Esqueceu sua senha?</a></small>
              </label>

              <b-modal
              id="modal-prevent-closing"
              ref="modal"
              hide-header
            >
              <form ref="form">
                <h4>Recupere sua senha!</h4>
                <b-form-group
                  label="Digite seu e-mail de recuperação"
                  label-for="email-rec-input"
                >
                  <b-form-input
                    id="email-rec-input"
                    required
                  ></b-form-input>
                </b-form-group>
              </form>
            </b-modal>

              <b-form-input
                id="password"
                type="password"
                placeholder="Digite sua senha"
              ></b-form-input>
            </b-form-group>

            <b-button
              type="button"
              variant="primary"
              block
              class="mt-2">
              <b-icon icon="arrow-bar-right"></b-icon> Entrar
            </b-button>

            <hr>

            <b-button
              type="button"
              variant="outline-secondary"
              block
              @click="CreateAccount">
              <b-icon icon="person-plus-fill"></b-icon> Não tenho conta
            </b-button>
        </b-form>

        <b-button
          type="button"
          variant="outline-secondary"
          block
          class="mt-2"
          @click="back">
          <b-icon icon="arrow90deg-left"></b-icon> Voltar
        </b-button>
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

.title-login {
  font-weight: bold;
}

.img-login {
  width: 600px;
}

.container-background {
  background: linear-gradient(to bottom, #ffffff, #d2d2d2);
  min-height: calc(87.3vh - 20px);
  padding-bottom: 5px;
}
</style>
