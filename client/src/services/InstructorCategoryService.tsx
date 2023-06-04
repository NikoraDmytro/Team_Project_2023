import axios from 'axios';
import { instructorCategory } from '../models/InstructorCategory';

const BASE_URL = process.env.REACT_APP_API_URL + 'instructorCategories/';

const InstructorCategoryService = {
    getAllInstructorCategories: async () => {
        return await axios.get<instructorCategory[]>(BASE_URL + 'all')
    }
}

export default InstructorCategoryService;