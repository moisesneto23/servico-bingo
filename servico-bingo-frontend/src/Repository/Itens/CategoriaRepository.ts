
import  { AppHttpAxios }  from '@/axios/AppHttpAxios';
import CategoriaModel from '@/Model/Itens/CategoriaModel';
import { Inject } from 'typescript-ioc';
import store from '@/store';
export class CategoriaRepository {
    
   
    @Inject
    private $http!: AppHttpAxios;
    private idEmpresa = this.pegaIdEmpresa();
    private pegaIdEmpresa(): number{
        let id = localStorage.getItem('businessId') || '0';
        return parseInt(id);
    }
   
    public async obterTodasCategorias(): Promise<CategoriaModel[]> {
        const result = await this.$http.get(`CategoriaItem/${this.idEmpresa}`);
        return result.data;
    }

    public async salvarCategoria(categoria: CategoriaModel): Promise<any> {
        categoria.empresaId = this.idEmpresa;
        const result = await this.$http.post('CategoriaItem', categoria);
    }

    public async editarCategoria(categoria: CategoriaModel): Promise<CategoriaModel> {
        const result = await this.$http.patch('CategoriaItem', categoria);
        return result.data;
    }
    public async delete(id: any) : Promise<any>{
        const url =`CategoriaItem/${id}`;
        await this.$http.delete(url);
    }
}