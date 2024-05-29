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

        <template #cell(idMaterial)="data">
          <span class="capitalize">{{ data.item.idMaterial }}</span>
        </template>

        <template #cell(peso)="data">
          <span>({{ data.item.peso }})</span>
        </template>

        <template #cell(valorTotal)="data">
          <span>R$ {{ data.item.valorTotal.toFixed(2) }}</span>
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
          class="recarregar"
          @click="recarregar"
        >
        <b-icon icon="arrow-clockwise" style="width: 15px;"></b-icon>
      </b-button>
    </div>

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
      fields: [
        {
          key: 'idMaterial',
          label: 'Material',
          sortable: true
        },
        {
          key: 'peso',
          label: 'Peso',
          sortable: true
        },
        {
          key: 'valorTotal',
          label: 'Valor',
          sortable: true
        }
      ]
    }
  },
  mounted () {
    this.list()
    EventBus.$on('updateUnidadeMedida', (unidadeMedida) => {
      this.unidadeMedida = unidadeMedida
    })
  },
  methods: {
    recarregar () {
      this.loading = true
      setTimeout(() => {
        this.list()
      }, 900)
    },
    list () {
      axios
        .get('http://localhost:8080/api/Historico')
        .then(response => {
          this.items = response.data
          this.loading = false
        })
        .catch(error => {
          console.log(error)
          this.loading = false
        })
    }
  }
}
</script>

<style scoped>
.container-input {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 3vh;
  margin-bottom: 3vh;
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
.recarregar {
  margin-left: 4rem;
  background-color: #062800;
  border-radius: 100%;
}
</style>
