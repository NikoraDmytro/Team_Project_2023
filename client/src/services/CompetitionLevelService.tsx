import axios from 'axios';
import { CompetitionLevel } from '../models/CompetitionLevel';

const BASE_URL = process.env.REACT_APP_API_URL + 'competitionLevels/';

const CompetitionLevelService = {
    getAllCompetitionLevels: async () => {
        return await axios.get<CompetitionLevel[]>(BASE_URL + 'all')
    }
}

export default CompetitionLevelService;