
import  { AppHttpAxios }  from '@/axios/AppHttpAxios';
import {CartelaModel} from '@/Model/CartelaModel';
import { Inject } from 'typescript-ioc';
import store from '@/store';
export class CartelaService {
    
   
    @Inject
    private $http!: AppHttpAxios;
    
   
    public async obterTodasCartelasPorNome(nome: string): Promise<CartelaModel[]> {
        nome = 'jose';
        const result = await this.$http.get(`TabelaBingo?nome=${nome}`);
        return result.data;
    }

    // public async salvarCategoria(categoria: CategoriaModel): Promise<any> {
    //     categoria.empresaId = this.idEmpresa;
    //     const result = await this.$http.post('CategoriaItem', categoria);
    // }

    // public async editarCategoria(categoria: CategoriaModel): Promise<CategoriaModel> {
    //     const result = await this.$http.patch('CategoriaItem', categoria);
    //     return result.data;
    // }
    // public async delete(id: any) : Promise<any>{
    //     const url =`CategoriaItem/${id}`;
    //     await this.$http.delete(url);
    // }
}