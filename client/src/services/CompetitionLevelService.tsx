import http from './index';
import { CompetitionLevel } from '../models/CompetitionLevel';

const BASE_URL = 'competitionLevels/';

const CompetitionLevelService = {
  getAllCompetitionLevels: async (): Promise<CompetitionLevel[]> => {
    return await http.get(BASE_URL + 'all');
  },
};

export default CompetitionLevelService;
