import  CategoriaModel  from '@/Model/Itens/CategoriaModel';
import {CategoriaRepository} from '@/Repository/Itens/CategoriaRepository';
import { Inject } from 'typescript-ioc';

export default class CategoriaService {
    
    @Inject
    private categoriaRepository!: CategoriaRepository;

    public async obterTodasCategorias(): Promise<CategoriaModel[]> {
        return await this.categoriaRepository.obterTodasCategorias();
    }

    public async salvarCategoria(categoria:CategoriaModel): Promise<any> {
         await this.categoriaRepository.salvarCategoria(categoria);
    }

    public async editarCategoria(categoria:CategoriaModel): Promise<CategoriaModel> {
       return await this.categoriaRepository.editarCategoria(categoria);
    }
    public async delete(id: number): Promise<any>{
        await this.categoriaRepository.delete(id);
    }
};