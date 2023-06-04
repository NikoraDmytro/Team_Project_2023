import React, { useEffect, useState } from 'react';
import { TableColumns } from '../../types/DataTableTypes';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import { DataTable } from '../../components/DataTable';
import belts from '../../const/belts';
import coachesLevel from '../../const/coachesLevel';
import './CoachesPage.scss';
import { CoachForm } from '../../components/CoachForm';
import { CoachService } from '../../services';
import { Coach } from '../../models/Coach';

type ColumnsType = Coach & { controls: string };

const CoachesPage = () => {
  const [coaches, setCoaches] = useState<Coach[]>([]);
  const [open, setOpen] = useState(false);
  const [selectedSex, setSelectedSex] = useState('');
  const [selectedBelt, setSelectedBelt] = useState('');
  const [selectedClub, setSelectedClub] = useState('');
  const [selectedCoachCategory, setSelectedCoachCategory] = useState('');

  const handleClose = () => setOpen(false);
  const handleChange = (field: string, value: string) => {
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
    const coachesData = response.map(coach => ({
      membershipCardNum: coach.membershipCardNum,
      firstName: coach.firstName,
      lastName: coach.lastName,
      patronymic: coach.patronymic,
      sex: coach.sex,
      birthDate: coach.birthDate,
      clubName: coach.clubName,
      belt: coach.belt,
      instructorCategory: coach.instructorCategory,
    }));
    setCoaches(coachesData);
  };

  useEffect(() => {
    fetchCoaches();
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
      renderItem: () => (
        <div className='control-buttons'>
          <EditIcon onClick={() => setOpen(true)} />
          <DeleteIcon className='delete-icon' />
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
              items={clubsTest}
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
          onClick={() => setOpen(true)}
        >
          Додати тренера
        </Button>
      </div>

      <DataTable tableData={coaches} tableColumns={columns} />
      <CoachForm open={open} setClose={handleClose} />
    </div>
  );
};

export { CoachesPage };

const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
