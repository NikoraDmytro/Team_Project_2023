import React, { useEffect, useState } from 'react';
import './Calendar.scss';
import { DataTable } from '../../components/DataTable';
import { Button, TextField } from '@mui/material';
import { TableColumns } from '../../types/DataTableTypes';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import regionalCenters from '../../const/cities';
import { CompetitionForm } from '../../components/CompetitionForm/CompetitionForm';
import { Competition } from '../../models/Competition';
import CompetitionStatusService from '../../services/CompetitionStatusService';
import CompetitionLevelService from '../../services/CompetitionLevelService';

type ColumnsType = Competition & { controls: string };

const CalendarPage = (): JSX.Element => {
  const [competitions, setCompetitions] = useState<Competition[]>([]);
  const [open, setOpen] = useState(false);
  const [selectedCity, setSelectedCity] = useState('');
  const [selectedStatus, setSelectedStatus] = useState('');
  const [selectedLevel, setSelectedLevel] = useState('');
  const [competitionLevels, setCompetitionLevels] = useState<string[]>([]);
  const [competitionStatuses, setCompetitionStatuses] = useState<string[]>([]);

  const handleClose = () => setOpen(false);

  const fetchCompetitionStatuses = async () => {
    var competitionStatuses = await CompetitionStatusService.getAllCompetitionStatuses();
    setCompetitionStatuses(competitionStatuses.data.map(x => x.name));
  }

  const fetchCompetitionLevels = async () => {
    var competitionLevels = await CompetitionLevelService.getAllCompetitionLevels();
    setCompetitionLevels(competitionLevels.data.map(x => x.name));
  }

  useEffect(() => {
    fetchCompetitionStatuses();
    fetchCompetitionLevels();
  }, []);

  const handleChange = (field: string, value: string) => {
    if (field === 'city') {
      setSelectedCity(value);
      setCompetitions(prev =>
        prev.filter(competition => competition.city === value),
      );
    } else if (field === 'level') {
      setSelectedLevel(value);
      setCompetitions(prev =>
        prev.filter(competition => competition.level === value),
      );
    } else {
      setSelectedStatus(value);
      setCompetitions(prev =>
        prev.filter(competition => competition.status === value),
      );
    }
  };

  const columns: TableColumns<Competition, ColumnsType>[] = [
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'weightingDate',
      label: 'Дата зважування',
    },
    {
      name: 'startDate',
      label: 'Дата початку',
      sortable: true,
    },
    {
      name: 'endDate',
      label: 'Дата закінчення',
    },
    {
      name: 'city',
      label: 'Місто',
    },
    {
      name: 'status',
      label: 'Статус',
      sortable: true,
    },
    {
      name: 'level',
      label: 'Рівень',
    },
    {
      name: 'controls',
      renderItem: () => (
        <div className='control-buttons'>
          <EditIcon onClick={() => setOpen(true)} />
          <DeleteIcon className='delete-icon' />
        </div>
      ),
    },
  ];

  return (
    <>
      <div className='calendar-wrapper'>
        <div className='calendar-menu'>
          <TextField label='Пошук'></TextField>
          <div className='filter-buttons'>
            <SelectForFilter
              label='Місто'
              items={regionalCenters}
              name='city'
              setFieldValue={handleChange}
            />
            <SelectForFilter
              label='Рівень'
              items={competitionLevels}
              name='level'
              setFieldValue={handleChange}
            />
            <TextField
              label='Дата початку'
              type='date'
              InputLabelProps={{
                shrink: true,
              }}
            />
            <SelectForFilter
              label='Статус'
              items={competitionStatuses}
              name='status'
              setFieldValue={handleChange}
            />
          </div>
          <Button
            variant='contained'
            color='inherit'
            onClick={() => setOpen(true)}
          >
            Додати змагання
          </Button>
        </div>

        <DataTable tableData={competitions} tableColumns={columns} />
      </div>
      <CompetitionForm open={open} setClose={handleClose} />
    </>
  );
};

export { CalendarPage };