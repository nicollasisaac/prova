import React,{useEffect,useState}from'react';
import axios from "axios"; // Importando axios

function Curriculo(){
  const [curriculo, setCurriculo] = useState(null);
  const [loading, setLoading] = useState(false);  // Controle de carregamento


  // Usando axios para buscar as empresas
  useEffect(() => {
    const fetchEmpresas = async () => {
      try {
        setLoading(true); // Inicia o carregamento
        const res = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/curriculo/1`);
        setCurriculo(res.data); // Popula o estado com as empresas retornadas
      } catch (err) {
        console.error("Erro ao buscar empresas:", err);
      } finally {
        setLoading(false); // Finaliza o carregamento
      }
    };
    fetchEmpresas(); // Chama a função para buscar as empresas
  }, []);

  return(
    <div style={{margin:'20px'}}>
      <h1>Nome</h1>
      <pre>{curriculo && ` – ${curriculo.nome}`}Nicollas</pre>
      <p>{curriculo && ` – ${curriculo.Biografia}`}</p>
      <p>{curriculo && ` – ${curriculo.Link}`}</p>
      <p>{curriculo && ` – ${curriculo.Habilidades}`}</p>
    </div>
  );
}
export default Curriculo;