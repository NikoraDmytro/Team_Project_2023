import React, { useEffect, useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import './Sportsman.scss';
import { SportsmenForm } from '../../components/SportsmenForm';
import { Sportsman } from '../../models/Sportsman';
import { SportsmanService } from '../../services';

type ColumnsType = Sportsman & { controls: string };

const SportsmanPage = () => {
  const [sportsmen, setSportsmen] = useState<Sportsman[]>([]);
  const [open, setOpen] = useState(false);

  const handleClose = () => setOpen(false);

  const fetchSportsmen = async () => {
    const response = await SportsmanService.getAllSportsmen();
    const data = response.map(sportsman => ({
      membershipCardNum: sportsman.membershipCardNum,
      firstName: sportsman.firstName,
      lastName: sportsman.lastName,
      patronymic: sportsman.patronymic,
      birthDate: sportsman.birthDate,
      belt: sportsman.belt,
      sex: sportsman.sex,
      clubName: sportsman.clubName,
      coachName: sportsman.coachName,
    }));

    setSportsmen(data);
  };

  useEffect(() => {
    fetchSportsmen();
  }, []);

  const columns: TableColumns<Sportsman, ColumnsType>[] = [
    {
      name: 'firstName',
      label: "Ім'я",
      sortable: true,
    },
    {
      name: 'lastName',
      label: 'Прізвище',
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
      name: 'belt',
      label: 'Пояс',
    },
    {
      name: 'coachName',
      label: "Ім'я тренера",
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
        <TextField label='Пошук' />
        <div className='groups-filters'>
          <div className='filter-buttons1'>
            <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
            <SelectForFilter label='Клуб' items={clubsTest} />
            <SelectForFilter label='Тренер' items={coachesTest} />
          </div>
          <div className='filter-buttons2'>
            <SelectForFilter label='Мін пояс' items={belts} />
            <SelectForFilter label='Макс пояс' items={belts} />
            <TextField label='Мін вік' />
            <TextField label='Макс вік' />
          </div>
        </div>
        <Button
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
        >
          Додати спортсмена
        </Button>
      </div>
      <DataTable tableData={sportsmen} tableColumns={columns} />
      <SportsmenForm open={open} setClose={handleClose} />
    </div>
  );
};

export { SportsmanPage };

const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
const coachesTest = ['Прокопенко Ю.С.', 'Прокопенко Ю.С.', 'Прокопенко Ю.С.'];
