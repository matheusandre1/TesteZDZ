<template>
  <v-container>
    <div class="d-flex justify-center">
      <v-card width="300px">
        <v-card-title class="text-h6 text-md-h5 text-lg-h6">Cadastramento Funcionário</v-card-title>
      </v-card>
    </div>

    <v-form v-model="valid" ref="form">
      <v-text-field v-model="funcionario.name" label="Nome" :rules="[v => !!v || 'Nome é obrigatório']"
        required></v-text-field>

      <v-text-field v-model="funcionario.lastName" label="Sobrenome"></v-text-field>

      <v-text-field v-model="funcionario.cpf" label="CPF"></v-text-field>

      <v-text-field v-model="funcionario.email" label="Email"></v-text-field>

      <v-text-field v-model="funcionario.phoneNumber" label="Número de Telefone"></v-text-field>

      <v-text-field v-model="funcionario.salary" label="Salário" type="number"></v-text-field>

      <v-text-field v-model="funcionario.address" label="Endereço"></v-text-field>

      <v-select v-model="funcionario.typeOfContract" :items="typeOfContract" item-text="label" item-value="value"
        label="Tipo de Contrato" :rules="[v => !!v || 'Tipo de contrato é obrigatório']" required></v-select>


      <v-btn @click="submitForm" :disabled="!valid" color="primary">Salvar</v-btn>

      <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
      <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>

    </v-form>

    <v-text-field v-model="searchId" label="Buscar Funcionário por ID" append-icon="mdi-magnify" single-line clearable
      class="mt-4" @input="fetchFuncionarioById"></v-text-field>

    <v-card v-if="foundFuncionario" class="mt-4">
      <v-card-title>{{ foundFuncionario.name }} {{ foundFuncionario.lastName }}</v-card-title>
      <v-card-subtitle>Email: {{ foundFuncionario.email }}</v-card-subtitle>
      <v-card-subtitle>Telefone: {{ foundFuncionario.phoneNumber }}</v-card-subtitle>
      <v-card-subtitle>Salário: {{ foundFuncionario.salary }}</v-card-subtitle>
      <v-card-subtitle>Endereço: {{ foundFuncionario.address }}</v-card-subtitle>
    </v-card>

    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>

    <v-text-field v-model="searchName" label="Busca Funcionario por Nome" append-icon="mdi-magnify" single-line
      clearable class="mt-4" @input="fetchFuncionarioByName"></v-text-field>

    <v-card v-if="foundFuncionariobyName" class="mt-4">
      <v-card-title>{{ foundFuncionariobyName.name }} {{ foundFuncionariobyName.lastName }}</v-card-title>
      <v-card-subtitle>Email: {{ foundFuncionariobyName.email }}</v-card-subtitle>
      <v-card-subtitle>Telefone: {{ foundFuncionariobyName.phoneNumber }}</v-card-subtitle>
      <v-card-subtitle>Salário: {{ foundFuncionariobyName.salary }}</v-card-subtitle>
      <v-card-subtitle>Endereço: {{ foundFuncionariobyName.address }}</v-card-subtitle>
    </v-card>

    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>

    <v-text-field v-model="DeleteById" label="Id do Funcionário para Deletar" clearable class="mt-4"></v-text-field>

    <v-btn @click="deleteFuncionarioById" color="red" class="mt-2">Deletar Funcionário</v-btn>

    <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>
  </v-container>
</template>


<script>
export default {
  data() {
    return {
      valid: false,
      DeleteById: '',
      errorMessage: '',
      searchName: '',
      searchId: '',
      successMessage: '',
      foundFuncionario: null,
      foundFuncionariobyName: '',
      errorMessage: '',
      funcionario: {
        name: '',
        lastName: '',
        cpf: '',
        email: '',
        phoneNumber: '',
        salary: '',
        address: '',
        typeOfContract: null,
      },
      typeOfContract: [{
        label: 'CLT', value: 1
      },
      { label: 'PJ', value: 2 }],
    };
  },
  methods: {
    async deleteFuncionarioById() {
      if (!this.DeleteById) {
        this.errorMessage = 'Por favor insira um Id valido.';
        this.successMessage = '';
        return;
      }

      try {
        const axios = await import('axios');

        const response = await axios.default.delete(`http://localhost:5140/api/Employee/deletebyId?id=${this.DeleteById}`)

        if (response.status === 200 || response.status === 204) {
          this.successMessage = "Funcionário Deletado Com Sucesso";
          this.errorMessage = '';
          this.DeleteById = '';
        }
        else {
          throw new Error('Erro ao deletar o Funcionario')
        }
      } catch (error) {
        this.successMessage = '';
        this.errorMessage = error.message || "Erro ao deletar";
      }
    },
    async fetchFuncionarioByName() {
      if (!this.searchName) {
        this.foundFuncionariobyName = null;
        this.errorMessage = ''
        return
      }

      try {
        const axios = await import('axios');
        const response = await axios.default.get(`http://localhost:5140/api/Employee/getByName?name=${this.searchName}`)

        if (response.status !== 200) {
          throw new Error("Funcionario não encontrado");
        }

        this.foundFuncionariobyName = response.data;
        this.errorMessage = '';
      } catch (error) {
        this.foundFuncionariobyName = null;
        this.errorMessage = error.message;
      }
    },
    async fetchFuncionarioById() {
      if (!this.searchId) {
        this.foundFuncionario = null;
        this.errorMessage = '';
        return;
      }

      try {
        const axios = await import('axios');

        const response = await axios.default.get(`http://localhost:5140/api/Employee/getById?id=${this.searchId}`);


        if (response.status !== 200) {
          throw new Error('Funcionário não encontrado');
        }

        this.foundFuncionario = response.data;
        this.errorMessage = '';
      } catch (error) {
        this.foundFuncionario = null;
        this.errorMessage = error.message;
      }
    },

    async submitForm() {
      try {
        const axios = await import('axios');

        if (this.$refs.form.validate()) {
          const response = await axios.default.post('http://localhost:5140/api/Employee/createEmployee', this.funcionario);
          console.log('Dados do formulário:', this.funcionario);
          console.log('Response da requisição:', response.data);
          this.successMessage = 'Funcionario criado com sucesso!';
          this.errorMessage = '';
        }
      } catch (error) {
        console.error('Erro ao enviar a requisição:', error);
      }
    }
  },
};
</script>

<style scoped></style>
