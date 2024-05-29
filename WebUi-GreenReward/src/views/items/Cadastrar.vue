<template>
  <div>

    <div class="container-input" responsive>
      <b-table
        v-if="!loading"
        striped
        sticky-header
        :items="items"
        :fields="fields"
        show-empty
        empty-text="Nenhum registro encontrado."
        class="tabela"
        label-sort-asc=""
        label-sort-desc=""
        label-sort-clear=""
      >

      <template #cell(nomeMaterial)="data">
        <span class="capitalize">{{ data.item.nomeMaterial }}</span>
      </template>

      <template #cell(unidadeMedida)="data">
        <span>({{ data.item.unidadeMedida }})</span>
      </template>

      <template #cell(valor)="data">
        <span>R$ {{ data.item.valor.toFixed(2) }}</span>
      </template>

      <template v-slot:cell(actions)="data">
        <b-button
          variant="success"
          size="sm"
          class="editar"
          @click="modalEdit(data.item)"
        >
        <b-icon icon="pencil-square" style="width: 15px;"></b-icon>
        </b-button>
          <b-button
            variant="danger"
            size="sm"
            @click="modalDelete(data.item)"
            style="margin-right: 10px;"
          >
          <b-icon icon="trash-fill" style="width: 15px;"></b-icon>
        </b-button>
      </template>
      </b-table>

      <div
        v-else
        class="d-flex align-items-center mb-1"
      >
        <b-spinner
          variant="success"
        />
        <p style="margin-left: 1rem;" class="mb-0 subsubtitulo">
          Aguarde enquanto os dados estão sendo carregados!
        </p>
      </div>
    </div>

    <div>
      <b-button
          size="md"
          class="adicionar"
          v-b-modal.adicionar
        >
        <b-icon icon="plus-lg" style="width: 15px;"></b-icon>
      </b-button>
      <b-button
          size="md"
          class="recarregar"
          @click="recarregar"
        >
        <b-icon icon="arrow-clockwise" style="width: 15px;"></b-icon>
      </b-button>
    </div>

    <b-modal
      id="modalEdit"
      ref="modalEdit"
      hide-header
      size="xl"
    >
    <div class="container-banner">
        <h1 class="titulo">Editar material</h1>
      </div>

      <div class="container-input">
        <b-form-input
          v-model="form_update.nomeMaterial"
          autocomplete="off"
          placeholder="*MATERIAL"
          class="input"
        ></b-form-input>
      </div>

      <div class="container-input">
        <b-form-select
          v-model="form_update.unidadeMedida"
          :options="options"
          autocomplete="off"
          placeholder="*UNIDADE DE MEDIDA"
          class="input"
          style="width: 50%;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>

      <div class="container-input">
        <b-form-input
          v-model="form_update.valor"
          autocomplete="off"
          placeholder="*VALOR"
          class="input"
          type="number"
          step="0.01"
          min="0"
        ></b-form-input>
      </div>

      <div class="container-input">
        <b-button @click="editar(form_update)" class="botao input">
          <small class="titulo-botao">EDITAR</small>
        </b-button>
      </div>
      <template #modal-footer>
        <b-button
          class="botao"
          @click="$refs.modalEdit.hide()"
          >
          <small
            class="titulo-botao"
            >
            FECHAR
          </small>
        </b-button>
      </template>
    </b-modal>

    <b-modal
      id="modalDelete"
      ref="modalDelete"
      hide-header
      size="xl"
    >
      <div class="container-banner">
        <h1 class="titulo">Excluir material</h1>
      </div>

      <div class="container-input">
        <h3 class="subtitulo">Você tem certeza que quer excluir o material?</h3>
      </div>

      <div class="container-input">
        <b-button @click="excluir(item)" class="botao input" style="background-color: red;border-color: red;">
          <small class="titulo-botao">EXCLUIR</small>
        </b-button>
      </div>

      <template #modal-footer>
        <b-button
          class="botao"
          @click="$refs.modalDelete.hide()"
          >
          <small
            class="titulo-botao"
            >
            FECHAR
          </small>
        </b-button>
      </template>

    </b-modal>

    <b-modal
      id="adicionar"
      ref="modal"
      hide-header
      size="xl"
    >
      <div class="container-banner">
        <h1 class="titulo">Adicionar material</h1>
      </div>

      <div class="container-input">
        <b-form-input
          v-model="nomeMaterial"
          autocomplete="off"
          placeholder="*MATERIAL"
          class="input"
          :state="materialState"
          required
        ></b-form-input>
      </div>

      <div class="container-input">
        <b-form-select
          v-model="unidadeMedida"
          :options="options"
          autocomplete="off"
          placeholder="*UNIDADE DE MEDIDA"
          class="input"
          :state="unidadeState"
          required
          style="width: 50%;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>

      <div class="container-input">
        <b-form-input
          v-model="valor"
          autocomplete="off"
          placeholder="*VALOR"
          type="number"
          class="input"
          step="0.01"
          min="0"
          :state="valorState"
          required
        ></b-form-input>
      </div>

      <div class="container-input">
        <b-button class="botao input" @click="adicionarMaterial" type="submit">
          <small class="titulo-botao">ADICIONAR</small>
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
import { EventBus } from '../../eventBus'
import axios from 'axios'

export default {
  data () {
    return {
      loading: true,
      items: [],
      form_update: {
        nomeMaterial: '',
        valor: '',
        unidadeMedida: ''
      },
      unidadeMedida: null,
      options: [
        { value: null, text: 'UNIDADE DE MEDIDA' },
        { value: 'kg', text: 'QUILO' },
        { value: 'g', text: 'GRAMA' },
        { value: 'mg', text: 'MILIGRAMA' }
      ],
      fields: [
        {
          key: 'nomeMaterial',
          label: 'Material',
          sortable: true
        },
        {
          key: 'unidadeMedida',
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
  mounted () {
    this.list()
  },
  methods: {
    recarregar () {
      this.loading = true
      setTimeout(() => {
        this.list()
      }, 900)
    },
    adicionarMaterial () {
      if (!this.nomeMaterial || !this.valor || !this.unidadeMedida) {
        // eslint-disable-next-line no-undef
        Toast.fire('Erro!', 'Os campos não devem estar vazios.', 'error')
        return
      }
      if (this.nomeMaterial && this.valor && this.unidadeMedida) {
        const DATA = [
          this.nomeMaterial,
          this.unidadeMedida,
          this.valor
        ]

        axios
          .post('http://localhost:8080/api/Material', {
            data: DATA,
            nomeMaterial: this.nomeMaterial,
            unidadeMedida: this.unidadeMedida,
            valor: this.valor
          })
          .then(response => {
            console.log(response)
            this.list()
            EventBus.$emit('updateUnidadeMedida', this.unidadeMedida)
            // eslint-disable-next-line no-undef
            Toast.fire('Material adicionado!', 'Prossiga para os próximos passos.', 'success')
            this.closeModal()
          })
          .catch(error => {
            console.error(error)
            // eslint-disable-next-line no-undef
            Toast.fire('Erro!', 'Ocorreu um erro.', 'error')
          })
      }
    },
    resetModal () {
      this.name = ''
      this.nameState = null
    },
    list () {
      axios
        .get('http://localhost:8080/api/Material')
        .then(response => {
          this.items = response.data
          this.loading = false
        })
        .catch(error => {
          console.log(error)
          this.loading = false
        })
    },
    closeModal () {
      setTimeout(() => {
        this.$bvModal.hide('adicionar')
      }, 500)
    },
    modalEdit (item) {
      this.$bvModal.show('modalEdit')
      this.form_update.id = item.id
      axios
        .get(`http://localhost:8080/api/Material/${item.id}`)
        .then(response => {
          const responseData = response.data
          this.form_update.nomeMaterial = responseData.nomeMaterial
          this.form_update.valor = responseData.valor
          this.form_update.unidadeMedida = responseData.unidadeMedida
        })
        .catch(error => {
          console.error(error)
          // eslint-disable-next-line no-undef
          Toast.fire('Erro!', 'Ocorreu um erro ao carregar os dados para edição.', 'error')
        })
    },
    editar (item) {
      if (!this.form_update.nomeMaterial || !this.form_update.valor || !this.form_update.unidadeMedida) {
        // eslint-disable-next-line no-undef
        Toast.fire('Erro!', 'Os campos não devem estar vazios.', 'error')
        return
      }
      if (this.form_update.nomeMaterial && this.form_update.valor && this.form_update.unidadeMedida) {
        axios
          .put(`http://localhost:8080/api/Material/${item.id}`, this.form_update)
          .then(response => {
            console.log(response)
            this.$bvModal.hide('modalEdit')
            EventBus.$emit('updateUnidadeMedida', this.form_update.unidadeMedida)
            // eslint-disable-next-line no-undef
            Toast.fire('Material Atualizado!', '', 'success')
            this.list()
          })
          .catch(error => {
            console.error(error)
            // eslint-disable-next-line no-undef
            Toast.fire('Erro!', 'Ocorreu um erro ao editar os dados.', 'error')
          })
      }
    },
    modalDelete (item) {
      this.item = item
      this.$bvModal.show('modalDelete')
    },
    closeModalDelete () {
      setTimeout(() => {
        this.$bvModal.hide('modalDelete')
      }, 500)
    },
    excluir (item) {
      axios
        .delete(`http://localhost:8080/api/Material/${item.id}`)
        .then((response) => {
          console.log(response)
          this.$bvModal.hide('modalDelete')
          // eslint-disable-next-line no-undef
          Toast.fire('Material Excluído!', '', 'success')
          this.list()
        })
        .catch((error) => {
        // eslint-disable-next-line no-undef
          Toast.fire('Erro!', 'Ocorreu um erro ao excluir o material.', 'error')
          console.error(error)
        })
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
  width: 50%;
  border-width: 0.215rem;
  border-color: black;
  border-radius: 30px;
  justify-content: center;
  align-items: center;
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
.recarregar {
  margin-left: 0.5rem;
  background-color: #062800;
  border-radius: 100%;
}
</style>
