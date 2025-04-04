import axios from 'axios';

const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

export async function getCurriculoById(id) {
  const response = await axios.get(`${API_BASE_URL}/api/curriculo/1`);
  return response.data;
}
