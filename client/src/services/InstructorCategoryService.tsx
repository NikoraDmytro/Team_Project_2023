import http from './index';
import { instructorCategory } from '../models/InstructorCategory';

const BASE_URL = 'instructorCategories/';

const InstructorCategoryService = {
  getAllInstructorCategories: async (): Promise<instructorCategory[]> => {
    return await http.get(BASE_URL + 'all');
  },
};

export default InstructorCategoryService;
