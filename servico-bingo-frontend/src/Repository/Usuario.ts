import Login from '@/views/visitante/Login.vue';
import  HttpAxios  from '@/axios/AppHttpAxios';
import { Inject } from 'typescript-ioc';

export class UsuarioRepository {
    @Inject
    private $http!: HttpAxios;

    public async fazerLogin(login: Login): Promise<string> {

        const result = await this.$http.post('https://localhost:7068/api/Usuario/Login',login);
        return result.data;
    }
}