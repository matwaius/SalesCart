<template>
<v-container class="fill-height" fluid>
        <v-row justify="center">
          <v-col cols="12" sm="8" md="4">
            <v-card class="ml-12 mr-12" ref="form">
              <v-card-text>

                <h1 class="bold">Login</h1>
                <br/>

                <v-form
                    ref="form"
                    v-model="valid"
                    lazy-validation
                  >

                    <v-text-field
                      v-model="formData.login"
                      outlined
                      label="Login"
                      required
                      :value="formData.login = (formData.login == null) ? formData.login : formData.login.toUpperCase()"
                    ></v-text-field>

                    <v-text-field
                      v-model="formData.password"
                      outlined
                      :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                      :type="show1 ? 'text' : 'password'"
                      @click:append="show1 = !show1"
                      label="Senha"
                      :value="formData.password = (formData.password == null) ? formData.password : formData.password.toUpperCase()"
                      required
                    ></v-text-field>

                      <v-row justify='end'>
                      <v-col class="text-right">
                        <v-btn color="primary" class="mr-3" @click="getUser">Entrar</v-btn>
                        <v-btn color="error" class="mr-0" @click="cleanForm">Limpar</v-btn>
                      </v-col>
                    </v-row>

                </v-form>
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
    </v-container>
</template>

<script>
import api from '@/services/api.ts';
export default {
  name: 'Signin',

  data: () => ({
    valid: true,
    formData: {
      name: '',
      login: '',
      password: ''
    },
    show1: false,
    password: 'Password'
  }),
  methods: {
    cleanForm () {
      this.formData.login = ""
      this.formData.password = ""
    },
    async getUser () {
      api.post("/Signin",this.formData)
          .then((response) => {
              this.$router.push({
                name: "Cart-Customer",
                params:{
                  id:response.data.id 
                }
            })
          })
          .catch((error) => {
              console.error(error.response);
          });
    }
  }
}
</script>

<style scoped>

bold {
  font-weight: bold;
}
</style>
