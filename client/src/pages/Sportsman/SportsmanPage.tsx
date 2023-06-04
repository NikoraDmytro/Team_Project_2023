import React, { useEffect, useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import './Sportsman.scss';
import { SportsmenForm } from '../../components/SportsmenForm';
import { Sportsman } from '../../models/Sportsman';
import {
  SportsmanService,
  CoachService,
  ClubService,
  BeltService,
} from '../../services';

type ColumnsType = Sportsman & { controls: string };

const SportsmanPage = () => {
  const [sportsmen, setSportsmen] = useState<Sportsman[]>([]);
  const [open, setOpen] = useState(false);
  const [update, setUpdate] = useState(false);
  const [sportsman, setSportsman] = useState<Sportsman>();
  const [coaches, setCoaches] = useState<string[]>([]);
  const [clubs, setClubs] = useState<string[]>([]);
  const [belts, setBelts] = useState<string[]>([]);

  const handleClose = () => setOpen(false);

  const getCoaches = async () => {
    var coaches = (await CoachService.getAllCoaches()).map(
      x => x.firstName + ' ' + x.lastName,
    );
    setCoaches(coaches);
  };

  const getClubs = async () => {
    var clubs = (await ClubService.getAllClubs()).map(x => x.name);
    setClubs(clubs);
  };

  const getBelts = async () => {
    var belts = (await BeltService.getAllBelts()).map(x => x.rank);
    setBelts(belts);
  };

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

  const editSportsman = (item: Sportsman) => {
    setUpdate(true);
    setSportsman(item);
    setOpen(true);
  };

  const createSportsman = () => {
    setUpdate(true);
    setOpen(true);
  };

  const deleteSportsman = async (id: number) => {
    await SportsmanService.deleteSportsman(id);
    fetchSportsmen();
  };

  useEffect(() => {
    getClubs();
    getCoaches();
    getBelts();
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
      renderItem: (item: Sportsman) => (
        <div className='control-buttons'>
          <EditIcon onClick={() => editSportsman(item)} />
          <DeleteIcon
            onClick={() => deleteSportsman(item.membershipCardNum)}
            className='delete-icon'
          />
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
            <SelectForFilter label='Клуб' items={clubs} />
            <SelectForFilter label='Тренер' items={coaches} />
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
          onClick={() => createSportsman()}
        >
          Додати спортсмена
        </Button>
      </div>
      <DataTable tableData={sportsmen} tableColumns={columns} />
      <SportsmenForm
        open={open}
        update={update}
        sportsman={sportsman}
        setClose={handleClose}
      />
    </div>
  );
};

export { SportsmanPage };
