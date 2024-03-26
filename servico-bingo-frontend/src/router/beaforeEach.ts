export default async (to: any, from: any, next: any) => {
  if (
    to.path === "/sobre" ||
    to.path === "/cadastro-usuario" ||
    to.path === "/login"
  ) {
    console.log("jwt apagado");
    localStorage.removeItem("ocirenegotnemacro");
    localStorage.removeItem("businessId");
    return next(true);
  }
   else if(!estaAutenticacao() ){
return next('/login');
    }
    else return next(true);
  
};

async function estaAutenticacao(): Promise<boolean> {
  if (localStorage.getItem("ocirenegotnemacro")) {
    return true;
  } else {
    return false;
  }
}
