import axios from 'axios';
import { JudgeCategory } from '../models/JudgeCategory';

const BASE_URL = process.env.REACT_APP_API_URL + 'judgeCategories/';

const JudgeCategoryService = {
    getAllJudgeCategories: async () => {
        return await axios.get<JudgeCategory[]>(BASE_URL + 'all')
    }
}

export default JudgeCategoryService;