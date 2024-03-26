export default async (to: any, from: any, next: any) => {
    if ( estaAutenticado()) {
        next(true);
      }else{
        localStorage.removeItem("ocirenegotnemacro");
        return next('/cartelas'); 
      }
    }
    
function estaAutenticado(): boolean {
  let autenticacao = localStorage.getItem("ocirenegotnemacro");
    if (autenticacao !== null ) {
      return true;
    } else {
      return  false;
    }
  }
  