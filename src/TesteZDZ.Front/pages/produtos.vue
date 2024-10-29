<template>
    <v-container>
        <v-card>
            <v-card-title class="text-h6">Cadastro de Produto</v-card-title>
            <v-card-text>
                <v-form v-model="valid" ref="form">
                    <v-text-field v-model="product.name" label="Nome" required></v-text-field>
                    <v-text-field v-model="product.description" label="Descrição" required></v-text-field>
                    <v-text-field v-model="product.quantity" label="Quantidade" type="number" required></v-text-field>
                    <v-text-field v-model="product.price" label="Preço" type="number" required></v-text-field>
                    <v-text-field v-model="product.validity" label="Data de Validade" type="date"
                        required></v-text-field>
                    <v-text-field v-model="product.supplier" label="Fornecedor" required></v-text-field>

                    <v-btn @click="submitForm" :disabled="!valid" color="primary">Salvar</v-btn>

                    <v-alert v-if="successMessage" type="success" class="mt-4">{{ successMessage }}</v-alert>


                    <v-alert v-if="errorMessage" type="error" class="mt-4">{{ errorMessage }}</v-alert>
                </v-form>

                <v-text-field v-model="searchId" label="Buscar Produto por ID" append-icon="mdi-magnify" single-line
                    clearable class="mt-4" @input="fetchProductById"></v-text-field>

                <v-card v-if="foundProduct" class="mt-4">
                    <v-card-title>{{ foundProduct.name }}</v-card-title>
                    <v-card-subtitle>Descrição: {{ foundProduct.description }}</v-card-subtitle>
                    <v-card-subtitle>Quantidade: {{ foundProduct.quantity }}</v-card-subtitle>
                    <v-card-subtitle>Preço: {{ foundProduct.price }}</v-card-subtitle>
                    <v-card-subtitle>Data de Validade: {{ foundProduct.validity }}</v-card-subtitle>
                    <v-card-subtitle>Fornecedor: {{ foundProduct.supplier }}</v-card-subtitle>
                </v-card>


                <v-btn @click="fetchAllProducts" color="primary" class="mt-4">Buscar Todos os Produtos</v-btn>
                <div v-if="allProducts && allProducts.length > 0" class="mt-4">
                    <v-card v-for="product in allProducts" :key="product.id" class="mb-2">
                        <v-card-title>{{ product.name }}</v-card-title>
                        <v-card-subtitle>Descrição: {{ product.description }}</v-card-subtitle>
                        <v-card-subtitle>Quantidade: {{ product.quantity }}</v-card-subtitle>
                        <v-card-subtitle>Preço: {{ product.price }}</v-card-subtitle>
                        <v-card-subtitle>Data de Validade: {{ product.validity }}</v-card-subtitle>
                        <v-card-subtitle>Fornecedor: {{ product.supplier }}</v-card-subtitle>
                    </v-card>
                </div>

                <v-text-field v-model="deleteById" label="ID do Produto para Deletar" clearable
                    class="mt-4"></v-text-field>
                <v-btn @click="deleteProductById" color="red" class="mt-2">Deletar Produto</v-btn>

                <h3 class="mt-4">Atualizar Produto</h3>
                <v-form v-model="updateValid" ref="updateForm">
                    <v-text-field v-model="updateProductById.id" label="ID do Produto" required></v-text-field>
                    <v-text-field v-model="updateProductById.name" label="Nome" required></v-text-field>
                    <v-text-field v-model="updateProductById.description" label="Descrição" required></v-text-field>
                    <v-text-field v-model="updateProductById.quantity" label="Quantidade" type="number"
                        required></v-text-field>
                    <v-text-field v-model="updateProductById.price" label="Preço" type="number" required></v-text-field>
                    <v-text-field v-model="updateProductById.validity" label="Data de Validade" type="date"
                        required></v-text-field>
                    <v-text-field v-model="updateProductById.supplier" label="Fornecedor" required></v-text-field>
                    <v-btn @click="updateProduct" :disabled="!updateValid" color="primary">Atualizar</v-btn>
                </v-form>

                <v-text-field v-model="supplierSearch" label="Buscar Produtos por Fornecedor" append-icon="mdi-magnify"
                    single-line clearable class="mt-4" @input="fetchProductsBySupplier"></v-text-field>


                <div v-if="supplierProducts && supplierProducts.length > 0" class="mt-4">
                    <v-card v-for="product in supplierProducts" :key="product.id" class="mb-2">

                        <v-card-title>Id :{{ product.id }}</v-card-title>
                        <v-card-subtitle>Nome: {{ product.name }}</v-card-subtitle>
                        <v-card-subtitle>Descrição: {{ product.description }}</v-card-subtitle>
                        <v-card-subtitle>Quantidade: {{ product.quantity }}</v-card-subtitle>
                        <v-card-subtitle>Preço: {{ product.price }}</v-card-subtitle>
                        <v-card-subtitle>Data de Validade: {{ product.validity }}</v-card-subtitle>
                        <v-card-subtitle>Fornecedor: {{ product.supplier }}</v-card-subtitle>
                    </v-card>
                </div>
            </v-card-text>
        </v-card>
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
            allProducts: [],
            foundProduct: null,
            supplierSearch: '',
            product: {
                name: '',
                description: '',
                quantity: 0,
                price: 0,
                validity: '',
                supplier: '',
            },
            updateProductById: {
                id: '',
                name: '',
                description: '',
                quantity: 0,
                price: 0,
                validity: '',
                supplier: '',
            },
            supplierProducts: [],
        };
    },
    methods: {
        async submitForm() {
            try {
                const axios = await import('axios');

                if (this.$refs.form.validate()) {
                    const response = await axios.default.post('http://localhost:5140/api/Product/createProduct', this.product);
                        this.successMessage = 'Produto criado com sucesso!';
                        this.errorMessage = '';
                    
                    
                }
            } catch (error) {
                this.errorMessage = 'Erro ao criar produto';
                this.successMessage = '';
            }
        },
        async fetchProductById() {
            if (!this.searchId) {
                this.foundProduct = null;
                this.errorMessage = '';
                return;
            }

            try {
                const axios = await import('axios');
                const response = await axios.default.get(`http://localhost:5140/api/Product/getById?id=${this.searchId}`);

                if (response.status === 200) {
                    this.foundProduct = response.data;
                    this.errorMessage = '';
                } else {
                    this.foundProduct = null;
                    this.errorMessage = 'Produto não encontrado';
                }
            } catch (error) {
                this.foundProduct = null;
                this.errorMessage = 'Erro ao buscar produto';
            }
        },
        async fetchAllProducts() {
            try {
                const axios = await import('axios');
                const response = await axios.default.get(`http://localhost:5140/api/Product/getAll`);
                this.allProducts = response.data;
            } catch (error) {
                this.allProducts = [];
                this.errorMessage = 'Erro ao buscar todos os produtos';
            }
        },
        async deleteProductById() {
            if (!this.deleteById) {
                this.errorMessage = 'Por favor, insira um ID válido.';
                return;
            }

            try {
                const axios = await import('axios');
                await axios.default.delete(`http://localhost:5140/api/Product/deleteById?id=${this.deleteById}`);
                this.successMessage = 'Produto deletado com sucesso';
                this.deleteById = '';
            } catch (error) {
                this.errorMessage = 'Erro ao deletar produto';
            }
        },
        async updateProduct() {
            try {
                const axios = await import('axios');
                const response = await axios.default.put(`http://localhost:5140/api/Product/update?id=${this.updateProductById.id}`, this.updateProductById);

                if (response.status === 200 || response.status === 204) {
                    this.successMessage = 'Produto atualizado com sucesso';
                } else {
                    this.errorMessage = 'Erro ao atualizar o produto';
                }
            } catch (error) {
                this.errorMessage = 'Erro ao atualizar produto';
            }
        },
        async fetchProductsBySupplier() {
            if (!this.supplierSearch) {
                this.supplierProducts = [];
                return;
            }

            try {
                const axios = await import('axios');
                const response = await axios.default.get(`http://localhost:5140/api/Product/GetSearchBySupplier?supplier=${this.supplierSearch}`);

                if (response.status === 200) {
                    this.supplierProducts = response.data.map(product => ({
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        quantity: product.quantity,
                        price: product.price,
                        validity: product.validity,
                        supplier: product.supplier,
                    }));
                } else {
                    this.supplierProducts = [];
                    this.errorMessage = 'Nenhum produto encontrado para o fornecedor especificado'
                }
            } catch (error) {
                this.supplierProducts = [];
                this.errorMessage = "Erro ao Buscar os Produtos por Fornecedor";
            }
        }
    },
};
</script>

<style scoped></style>