import axios from 'axios';
import { Belt } from '../models/Belt';

const BASE_URL = process.env.REACT_APP_API_URL + 'belts/';

const BeltService = {
    getAllBelts: async () => {
        return await axios.get<Belt[]>(BASE_URL)
    }
}

export default BeltService;