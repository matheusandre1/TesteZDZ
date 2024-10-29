<template>
    <v-container>
      <div class="d-flex justify-center">
        <v-card width="300px">
          <v-card-title class="text-h6 text-md-h5 text-lg-h6">Cadastro de Despesa</v-card-title>
        </v-card>
      </div>
  
      <v-form v-model="valid" ref="form">
        <v-text-field
          v-model="expense.description"
          label="Descrição"
          :rules="[]"
          required
        ></v-text-field>
  
        <v-select
          v-model="expense.category"
          :items="categoryOptions"
          label="Categoria"
          :rules="[]"
          required
        ></v-select>
  
        <v-text-field
          v-model="expense.value"
          label="Valor"
          type="number"
          :rules="[]"
          required
        ></v-text-field>
  
        <v-select
          v-model="expense.paymentMethod"
          :items="paymentMethodOptions"
          label="Método de Pagamento"
          :rules="[]"
          required
        ></v-select>
  
        <v-btn @click="submitForm" :disabled="!valid" color="primary">Salvar</v-btn>
      </v-form>  

      
      
      <v-text-field
        v-model="searchId"
        label="Buscar Despesa por ID"
        append-icon="mdi-magnify"
        single-line
        clearable
        class="mt-4"
        @input="fetchExpenseById"
      ></v-text-field>
  
      
      <v-card v-if="foundExpense" class="mt-4">
        <v-card-title>{{ foundExpense.description }}</v-card-title>
        <v-card-subtitle>Categoria: {{ foundExpense.category }}</v-card-subtitle>
        <v-card-subtitle>Valor: {{ foundExpense.value }}</v-card-subtitle>
        <v-card-subtitle>Método de Pagamento: {{ foundExpense.paymentMethod }}</v-card-subtitle>
      </v-card>
  
      
      <v-select
        v-model="selectedCategory"
        :items="categoryOptions"
        label="Buscar Despesa por Categoria"
        clearable
        class="mt-4"
        @change="fetchExpenseByCategory"
      ></v-select>
      <v-btn @click="fetchExpenseByCategory" color="primary" class="mt-2">Buscar</v-btn>

      <div v-if="expensesByCategory.length > 0" class="mt-4">
  <v-card v-for="expense in expensesByCategory" :key="expense.id" class="mb-2">
    <v-card-title>{{ expense.description }}</v-card-title>
    <v-card-subtitle>Categoria: {{ expense.category }}</v-card-subtitle>
    <v-card-subtitle>Valor: {{ expense.value }}</v-card-subtitle>
    <v-card-subtitle>Método de Pagamento: {{ expense.paymentMethod }}</v-card-subtitle>
  </v-card>
</div>

  
      
      <v-select
        v-model="selectedPaymentMethod"
        :items="paymentMethodOptions"
        label="Buscar Despesa por Método de Pagamento"
        clearable
        class="mt-4"
        @change="fetchExpenseByPaymentMethod"
      ></v-select>
      <v-btn @click="fetchExpenseByPaymentMethod" color="primary" class="mt-2">Buscar</v-btn>

      <div v-if="expensesByPaymentMethod.length > 0" class="mt-4">
        <v-card v-for="expense in expensesByPaymentMethod" :key="expense.id" class="mb-2">
        <v-card-title>{{ expense.description }}</v-card-title>
        <v-card-subtitle>Categoria: {{ expense.category }}</v-card-subtitle>
        <v-card-subtitle>Valor: {{ expense.value }}</v-card-subtitle>
        <v-card-subtitle>Método de Pagamento: {{ expense.paymentMethod }}</v-card-subtitle>
      </v-card>
      </div>

      <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>
  
      
      <v-text-field
        v-model="deleteById"
        label="ID da Despesa para Deletar"
        clearable
        class="mt-4"
      ></v-text-field>
  
      <v-btn @click="deleteExpenseById" color="red" class="mt-2">Deletar Despesa</v-btn>
  
      
      <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>
      <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>
    </v-container>
  </template>
  
  <script>
  export default {
    data() {
      return {
        valid: false,
        deleteById: '',
        successMessage: '',
        errorMessage: '',
        searchId: '',
        selectedCategory: null,
        selectedPaymentMethod: null,
        expensesByCategory: [],
        expensesByPaymentMethod: [],
        foundExpense: null,
        expense: {
          description: '',
          category: null,
          value: '',
          paymentMethod: null,
        },
        categoryOptions: [
          { text: 'Tecnologia', value: 0 },
          { text: 'Operacional', value: 1 },
          { text: 'Administrativo', value: 2 },
          { text: 'Financeiro', value: 3 },
          { text: 'Vendas', value: 4 },
        ],
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
            const response = await axios.default.post('http://localhost:5140/api/Expense/createExpense', this.expense);
            console.log('Dados do formulário:', this.expense);
            console.log('Response da requisição:', response.data);
            this.successMessage = 'Despesa criada com sucesso!';
            this.errorMessage = '';
          }
        } catch (error) {
          console.error('Erro ao enviar a requisição:', error);
          this.errorMessage = 'Erro ao criar despesa';
        }
      },
      async fetchExpenseById() {
        if (!this.searchId) {
          this.foundExpense = null;
          this.errorMessage = '';
          return;
        }
  
        try {
          const axios = await import('axios');
          const response = await axios.default.get(`http://localhost:5140/api/Expense/getById?id=${this.searchId}`);
          
          if (response.status !== 200) {
            throw new Error('Despesa não encontrada');
          }
          
          this.foundExpense = response.data;
          this.errorMessage = '';
        } catch (error) {
          this.foundExpense = null;
          this.errorMessage = error.message || 'Erro ao buscar despesa';
        }
      },
      async fetchExpenseByCategory() {
        if (this.selectedCategory == null || this.selectedCategory === '') {
   this.expensesByCategory = [];          
   return;
   }

  
        try {
          const axios = await import('axios');
          const response = await axios.default.get(`http://localhost:5140/api/Expense/byCategory?category=${this.selectedCategory}`);

          console.log('Dados retornadors da Api:', response.data);
          
          if (response.status !== 200) {
            throw new Error('Despesa não encontrada para a categoria selecionada');
          }
          
          this.expensesByCategory = response.data;
          this.errorMessage = '';
        } catch (error) {
          console.error(error);
          this.expensesByCategory = [];
          this.errorMessage = error.message || 'Erro ao buscar despesa por categoria';
        }
      },
      async fetchExpenseByPaymentMethod() {

        if (this.selectedPaymentMethod == null || this.selectedPaymentMethod === '') {
   this.selectedPaymentMethod = [];          
   return ;
   }
          
        try {
          const axios = await import('axios');
          const response = await axios.default.get(`http://localhost:5140/api/Expense/byPaymentMethod?paymentMethod=${this.selectedPaymentMethod}`);
          
          
          console.log('Dados retornadors da Api:', response.data);

          if (response.status !== 200) {
            throw new Error('Despesa não encontrada para o método de pagamento selecionado');
          }
          
          this.expensesByPaymentMethod = response.data;
          this.errorMessage = '';
        } catch (error) {
          this.expensesByPaymentMethod = [];
          this.errorMessage = error.message || 'Erro ao buscar despesa por método de pagamento';
        }
      },
      async deleteExpenseById() {
        if (!this.deleteById) {
          this.errorMessage = 'Por favor, insira um ID válido.';
          this.successMessage = '';
          return;
        }
  
        try {
          const axios = await import('axios');
          const response = await axios.default.delete(`http://localhost:5140/api/Expense/deleteById?id=${this.deleteById}`);
          
          if (response.status === 200 || response.status === 204) {
            this.successMessage = 'Despesa deletada com sucesso';
            this.errorMessage = '';
            this.deleteById = '';
          } else {
            throw new Error('Erro ao deletar a despesa');
          }
        } catch (error) {
          this.successMessage = '';
          this.errorMessage = error.message || 'Erro ao deletar';
        }
      }
    }
  };
  </script>
  
  
  <style scoped>
  </style>
  