import axios from 'axios';
import { CompetitionStatus } from '../models/CompetitionStatus';

const BASE_URL = 'competitionStatuses/';

const CompetitionStatusService = {
  getAllCompetitionStatuses: async () => {
    return await axios.get<CompetitionStatus[]>(BASE_URL + 'all');
  },
};

export default CompetitionStatusService;
