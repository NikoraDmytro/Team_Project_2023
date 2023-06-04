import React, { useEffect, useState } from 'react';
import { TableColumns } from '../../types/DataTableTypes';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import { DataTable } from '../../components/DataTable';
import coachesLevel from '../../const/coachesLevel';
import './CoachesPage.scss';
import { CoachForm } from '../../components/CoachForm';
import { CoachService } from '../../services';
import { Coach } from '../../models/Coach';
import BeltService from '../../services/BeltService';
import ClubService from '../../services/ClubService';

type ColumnsType = Coach & { controls: string };

const CoachesPage = () => {
  const [coaches, setCoaches] = useState<Coach[]>([]);
  const [filteredCoaches, setFilteredCoaches] = useState<Coach[]>([]);
  const [open, setOpen] = useState(false);
  const [belts, setBelts] = useState<string[]>([]);
  const [clubs, setClubs] = useState<string[]>([]);
  const [update, setUpdate] = useState(false);
  const [coach, setCoach] = useState<Coach>();
  const [selectedSex, setSelectedSex] = useState('');
  const [selectedBelt, setSelectedBelt] = useState('');
  const [selectedClub, setSelectedClub] = useState('');
  const [selectedCoachCategory, setSelectedCoachCategory] = useState('');

  const handleClose = () => setOpen(false);
  const handleChange = (field: string, value: string) => {
    var filtered = filteredCoaches;

    if (field === 'sex') {
      setSelectedSex(value);
      setCoaches(prev => prev.filter(coach => coach.sex === value));
    } else if (field === 'belt') {
      setSelectedBelt(value);
      setCoaches(prev => prev.filter(coach => coach.belt === value));
    } else if (field === 'club') {
      setSelectedClub(value);
      setCoaches(prev => prev.filter(coach => coach.clubName === value));
    } else if (field === 'coachCategory') {
      setSelectedCoachCategory(value);
      setCoaches(prev =>
        prev.filter(coach => coach.instructorCategory === value),
      );
    }
  };

  const fetchCoaches = async () => {
    const response = await CoachService.getAllCoaches();
    setCoaches(response);
    setFilteredCoaches(response);
  };

  const fetchBelts = async () => {
    const response = await BeltService.getAllBelts();
    setBelts(response.map(x => x.rank));
  };

  const fetchClubs = async () => {
    const response = await ClubService.getAllClubs();
    setClubs(response.map(x => x.name));
  };

  const editCoach = async (item: Coach) => {
    setUpdate(true);
    setCoach(item);
    setOpen(true);
  };

  const createCoach = async () => {
    setUpdate(false);
    setOpen(true);
  };

  const deleteCoach = async (id: number) => {
    await CoachService.deleteCoach(id);
    fetchCoaches();
  }

  useEffect(() => {
    fetchCoaches();
    fetchBelts();
    fetchClubs();
  }, []);

  const columns: TableColumns<Coach, ColumnsType>[] = [
    {
      name: 'firstName',
      label: "Ім'я",
      sortable: true,
    },
    {
      name: 'lastName',
      label: 'Прізвище',
      sortable: true,
    },
    {
      name: 'patronymic',
      label: 'По-батькові',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'phone',
      label: 'Номер телефону',
    },
    {
      name: 'belt',
      label: 'Пояс',
      sortable: true,
    },
    {
      name: 'birthDate',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'clubName',
      label: 'Клуб',
    },
    {
      name: 'instructorCategory',
      label: 'Інструкторська категорія',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
    {
      name: 'controls',
      renderItem: (item: Coach) => (
        <div className='control-buttons'>
          <EditIcon onClick={() => editCoach(item)} />
          <DeleteIcon onClick={() => deleteCoach(item.membershipCardNum)} className='delete-icon' />
        </div>
      ),
    },
  ];
  return (
    <div className='wrapper'>
      <div className='menu'>
        <TextField label='Пошук'></TextField>
        <div className='filter-buttons'>
          <div className='first-buttons'>
            <SelectForFilter
              label='Стать'
              items={['Ч', 'Ж']}
              name='sex'
              setFieldValue={handleChange}
            />
            <SelectForFilter
              label='Пояс'
              items={belts}
              name='belt'
              setFieldValue={handleChange}
            />
          </div>
          <div className='second-buttons'>
            <SelectForFilter
              label='Клуб'
              items={clubs}
              name='club'
              setFieldValue={handleChange}
            />
            <SelectForFilter
              label='Категорія'
              items={coachesLevel}
              name='coachCategory'
              setFieldValue={handleChange}
            />
          </div>
        </div>
        <Button
          variant='contained'
          color='inherit'
          onClick={() => createCoach()}
        >
          Додати тренера
        </Button>
      </div>

      <DataTable tableData={coaches} tableColumns={columns} />
      <CoachForm
        open={open}
        update={update}
        coach={coach}
        setClose={handleClose}
      />
    </div>
  );
};

export { CoachesPage };
