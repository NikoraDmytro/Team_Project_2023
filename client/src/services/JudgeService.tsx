import axios from 'axios';
import { Judge } from '../models/Judge';

const BASE_URL = process.env.REACT_APP_API_URL + 'judges/';

const JudgeService = {
    getAllJudges: async () => {
        return await axios.get<Judge[]>(BASE_URL + 'all')
    },

    createJudge: async (judge: any) => {
        return await axios.post(BASE_URL, judge);
    },

    updateJudge: async (membershipCardNum: number, judge: any) => {
        return await axios.put(BASE_URL + membershipCardNum, judge);
    },

    deleteJudge: async (id: number) => {
        return await axios.delete(BASE_URL + id);
    }
}

export default JudgeService;