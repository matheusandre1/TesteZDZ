<template>
  <v-container>
    <div class="d-flex justify-center">
      <v-card width="300px">
        <v-card-title class="text-h6 text-md-h5 text-lg-h6">Cadastro de Receita</v-card-title>
      </v-card>
    </div>

    <v-form v-model="valid" ref="form">
      <v-text-field v-model="revenue.CNPJ" label="CNPJ" :rules="[]"></v-text-field>

      <v-text-field v-model="revenue.description" label="Descrição" :rules="[]"></v-text-field>

      <v-text-field v-model="revenue.value" label="Valor" type="number" :rules="[]"></v-text-field>

      <v-select v-model="revenue.paymentMethod" :items="paymentMethodOptions" label="Método de Pagamento" :rules="[]"
        required></v-select>

      <v-btn @click="submitForm" :disabled="!valid" color="primary">Salvar</v-btn>
    </v-form>
    <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>

    <v-text-field v-model="searchId" label="Buscar Receita por ID" append-icon="mdi-magnify" single-line clearable
      class="mt-4" @input="fetchRevenueById"></v-text-field>

    <v-card v-if="foundRevenue" class="mt-4">
      <v-card-title>{{ foundRevenue.description }}</v-card-title>
      <v-card-subtitle>CNPJ: {{ foundRevenue.CNPJ }}</v-card-subtitle>
      <v-card-subtitle>Valor: {{ foundRevenue.value }}</v-card-subtitle>
      <v-card-subtitle>Método de Pagamento: {{ foundRevenue.paymentMethod }}</v-card-subtitle>
    </v-card>
    <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>

    <v-btn @click="fetchAllRevenues" color="primary" class="mt-4">Buscar Todas as Receitas</v-btn>

    <div v-if="allRevenues.length > 0" class="mt-4">
      <v-card v-for="revenue in allRevenues" :key="revenue.id" class="mb-2">
        <v-card-title>{{ revenue.description }}</v-card-title>
        <v-card-subtitle>CNPJ: {{ revenue.CNPJ }}</v-card-subtitle>
        <v-card-subtitle>Valor: {{ revenue.value }}</v-card-subtitle>
        <v-card-subtitle>Método de Pagamento: {{ revenue.paymentMethod }}</v-card-subtitle>
      </v-card>
    </div>

    <v-select v-model="selectedPaymentMethod" :items="paymentMethodOptions"
      label="Buscar Receita por Método de Pagamento" clearable class="mt-4"
      @change="fetchRevenueByPaymentMethod"></v-select>
    <v-btn @click="fetchRevenueByPaymentMethod" color="primary" class="mt-2">Buscar</v-btn>

    <div v-if="revenuesByPaymentMethod.length > 0" class="mt-4">
      <v-card v-for="revenue in revenuesByPaymentMethod" :key="revenue.id" class="mb-2">
        <v-card-title>{{ revenue.description }}</v-card-title>
        <v-card-subtitle>CNPJ: {{ revenue.CNPJ }}</v-card-subtitle>
        <v-card-subtitle>Valor: {{ revenue.value }}</v-card-subtitle>
        <v-card-subtitle>Método de Pagamento: {{ revenue.paymentMethod }}</v-card-subtitle>
      </v-card>
    </div>

    <v-text-field v-model="deleteById" label="ID da Receita para Deletar" clearable class="mt-4"></v-text-field>

    <v-btn @click="deleteRevenueById" color="red" class="mt-2">Deletar Receita</v-btn>

    <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>
    
    <br></br><h3>Atualizar Receita</h3>
<v-form v-model="updateValid" ref="updateForm">
    <v-text-field v-model="updateRevenueById.id" label="ID da Receita" :rules="[]" required></v-text-field>
    <v-text-field v-model="updateRevenueById.CNPJ" label="CNPJ" :rules="[]" required></v-text-field>
    <v-text-field v-model="updateRevenueById.description" label="Descrição" :rules="[]" required></v-text-field>
    <v-text-field v-model="updateRevenueById.value" label="Valor" type="number" :rules="[]" required></v-text-field>
    <v-select v-model="updateRevenueById.paymentMethod" :items="paymentMethodOptions" label="Método de Pagamento" :rules="[]" required></v-select>
    <v-btn @click="updateRevenue" :disabled="!updateValid" color="primary">Atualizar</v-btn>
    <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>
</v-form>

  </v-container>
</template>


<script>
export default {
  data() {
    return {
      valid: false,
      updateValid: false,
      deleteById: '',
      successMessage: '',
      errorMessage: '',
      searchId: '',
      selectedPaymentMethod: null,
      allRevenues: [],
      revenuesByPaymentMethod: [],
      foundRevenue: null,
      revenue: {
        CNPJ: '',
        description: '',
        value: '',
        paymentMethod: null,
      },
      updateRevenueById: {
        id: '',
        CNPJ: '',
        description: '',
        value: '',
        paymentMethod: null
      },
      paymentMethodOptions: [
        { text: 'Pix', value: 0 },
        { text: 'Cartão de Crédito', value: 1 },
        { text: 'Cartão de Débito', value: 2 },
      ],
    };
  },
  methods: {
    async submitForm() {
      try {
        const axios = await import('axios');

        if (this.$refs.form.validate()) {
          const response = await axios.default.post('http://localhost:5140/api/Revenue/createRevenue', this.revenue);
          console.log('Dados do formulário:', this.revenue);
          console.log('Response da requisição:', response.data);
          this.successMessage = 'Receita criada com sucesso!';
          this.errorMessage = '';
        }
      } catch (error) {
        console.error('Erro ao enviar a requisição:', error);
        this.errorMessage = 'Erro ao criar receita';
      }
    },
    async fetchRevenueById() {
      if (!this.searchId) {
        this.foundRevenue = null;
        this.errorMessage = '';
        return;
      }

      try {
        const axios = await import('axios');
        const response = await axios.default.get(`http://localhost:5140/api/Revenue/getById?id=${this.searchId}`);

        if (response.status !== 200) {
          throw new Error('Receita não encontrada');
        }

        this.foundRevenue = response.data;
        this.errorMessage = '';
      } catch (error) {
        this.foundRevenue = null;
        this.errorMessage = error.message || 'Erro ao buscar receita';
      }
    },
    async fetchAllRevenues() {
      try {
        const axios = await import('axios');
        const response = await axios.default.get(`http://localhost:5140/api/Revenue/getAll`);

        this.allRevenues = response.data;
        this.errorMessage = '';
      } catch (error) {
        console.error(error);
        this.allRevenues = [];
        this.errorMessage = error.message || 'Erro ao buscar todas as receitas';
      }
    },
    async fetchRevenueByPaymentMethod() {
      if (this.selectedPaymentMethod == null || this.selectedPaymentMethod === '') {
        this.revenuesByPaymentMethod = [];
        return;
      }

      try {
        const axios = await import('axios');
        const response = await axios.default.get(`http://localhost:5140/api/Revenue/getPaymentMethod?paymentMethod=${this.selectedPaymentMethod}`);

        console.log('Dados retornados da Api:', response.data);

        if (response.status !== 200) {
          throw new Error('Receitas não encontradas para o método de pagamento selecionado');
        }

        this.revenuesByPaymentMethod = response.data;
        this.errorMessage = '';
      } catch (error) {
        this.revenuesByPaymentMethod = [];
        this.errorMessage = error.message || 'Erro ao buscar receita por método de pagamento';
      }
    },
    async deleteRevenueById() {
      if (!this.deleteById) {
        this.errorMessage = 'Por favor, insira um ID válido.';
        this.successMessage = '';
        return;
      }

      try {
        const axios = await import('axios');
        const response = await axios.default.delete(`http://localhost:5140/api/Revenue/deleteById?id=${this.deleteById}`);

        if (response.status === 200 || response.status === 204) {
          this.successMessage = 'Receita deletada com sucesso';
          this.errorMessage = '';
          this.deleteById = '';
        } else {
          throw new Error('Erro ao deletar a receita');
        }
      } catch (error) {
        this.successMessage = '';
        this.errorMessage = error.message || 'Erro ao deletar';
      }
    },
    async updateRevenue() {
      
      if (!this.updateRevenueById) {
        this.errorMessage = 'Por favor, insira um ID válido.';
        this.successMessage = '';
        return; 
      }

      try {
        const axios = await import('axios');

       
        const response = await axios.default.put(`http://localhost:5140/api/Revenue/update?id=${this.updateRevenueById.id}`, {
          CNPJ: this.updateRevenueById.CNPJ,
          description: this.updateRevenueById.description,
          value: this.updateRevenueById.value,
          paymentMethod: this.updateRevenueById.paymentMethod,
        });

        
        if (response.status === 200 || response.status === 204) {
          this.successMessage = 'Receita atualizada com sucesso';
          this.errorMessage = '';
          
          this.updateRevenueById = { id: '', CNPJ: '', description: '', value: '', paymentMethod: null };
        } else {
          throw new Error('Erro ao atualizar a receita');
        }
      } catch (error) {
        this.successMessage = '';
        
        console.error('Erro na atualização:', error);
        this.errorMessage = error.message || 'Erro ao atualizar';
      }
    }

  }
};
</script>


<style scoped>

</style>