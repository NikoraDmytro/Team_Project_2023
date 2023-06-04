import axios from 'axios';
import { Division } from '../models/Division';

const BASE_URL = process.env.REACT_APP_API_URL + 'divisions/';

const DivisionService = {
    getAllDivisions: async () => {
        return await axios.get<Division[]>(BASE_URL + 'all')
    }
}

export default DivisionService;