import http from './index';
import { CompetitionStatus } from '../models/CompetitionStatus';

const BASE_URL = 'competitionStatuses/';

const CompetitionStatusService = {
  getAllCompetitionStatuses: async (): Promise<CompetitionStatus[]> => {
    return await http.get(BASE_URL + 'all');
  },
};

export default CompetitionStatusService;
