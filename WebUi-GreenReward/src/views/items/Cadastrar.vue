<template>
  <div>

    <div class="container-input" responsive>
      <b-table
        striped
        sticky-header
        :items="items"
        :fields="fields"
        class="tabela"
        label-sort-asc=""
        label-sort-desc=""
        label-sort-clear=""
      >
      <template v-slot:cell(actions)="data">
        <b-button
          variant="success"
          size="sm"
          class="editar"
          @click="editar(data.id)"
        >
        <b-icon icon="pencil-square" style="width: 15px;"></b-icon>
      </b-button>
        <b-button
          variant="danger"
          size="sm"
          @click="excluir(data.id)"
          style="margin-right: 10px;"
        >
        <b-icon icon="trash-fill" style="width: 15px;"></b-icon>
      </b-button>
      </template>
    </b-table>
    </div>

    <div>
      <b-button
          size="md"
          class="adicionar"
          v-b-modal.adicionar
        >
        <b-icon icon="plus-lg" style="width: 15px;"></b-icon>
      </b-button>
    </div>

    <b-modal
      id="adicionar"
      ref="modal"
      hide-header
      size="xl"
    >
      <material />
      <div class="container-input">
        <b-button class="botao input">
          <small class="titulo-botao" @click="mostraToast">ADICIONAR</small>
        </b-button>
      </div>
      <template #modal-footer>
        <b-button
          class="botao"
          @click="$refs.modal.hide()"
          >
          <small
            class="titulo-botao"
            >
            FECHAR
          </small>
        </b-button>
      </template>
    </b-modal>

  </div>
</template>

<script>
import Material from '../components/Material.vue'

export default {
  components: {
    Material
  },
  data () {
    return {
      items: [
        { id: 1, material: 'Papelão', unidade: '(Kg)', valor: 'R$0,67' },
        { id: 2, material: 'Ouro', unidade: '(g)', valor: 'R$349,45' }
      ],
      fields: [
        {
          key: 'material',
          label: 'Material',
          sortable: true
        },
        {
          key: 'unidade',
          label: 'Unidade de Medida',
          sortable: true
        },
        {
          key: 'valor',
          label: 'Valor',
          sortable: true
        },
        {
          key: 'actions',
          label: 'Ações'
        }
      ]
    }
  },
  methods: {
    mostraToast () {
      // eslint-disable-next-line no-undef
      Toast.fire('Material adicionado!', 'Prossiga para os próximos passos.', 'success')
      this.closeModal()
    },
    resetModal () {
      this.name = ''
      this.nameState = null
    },
    handleOk (bvModalEvent) {
      bvModalEvent.preventDefault()
      this.handleSubmit()
    },
    handleSubmit () {
      if (!this.checkFormValidity()) {
        return
      }
      this.submittedNames.push(this.name)
      this.$nextTick(() => {
        this.$bvModal.hide('adicionar')
      })
    },
    closeModal () {
      setTimeout(() => {
        this.$bvModal.hide('adicionar')
      }, 1500)
    }
  }
}
</script>

<style scoped>
.container-banner {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 2%;
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
.botao:hover {
  background-color: #319950;
}
.input {
  width: 25%;
  border-width: 0.215rem;
  border-color: black;
  border-radius: 30px;
}
.tabela {
  width: 90%;
  text-align: center;
  vertical-align: middle;
}
.editar {
  margin-right: 10px;
  background-color: #225B18;
}
.adicionar {
  margin-left: 4rem;
  background-color: #062800;
  border-radius: 100%;
}
</style>
