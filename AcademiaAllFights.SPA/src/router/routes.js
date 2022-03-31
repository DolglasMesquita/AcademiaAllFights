
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue'), name: 'index',  meta: { requiresAuth: true }},
      { path: '/aluno', component: () => import('src/pages/Aluno/Alunos.vue') },
      { path: '/aluno/public', component: () => import('src/pages/AlunoPublic/Alunos.vue') },
      { path: '/aluno/adicionar', component: () => import('src/pages/Aluno/AlunoAdicionar.vue') },
      { path: '/aluno/editar/:id', component: () => import('src/pages/Aluno/AlunoEditar.vue') },
      { path: '/professor', component: () => import('src/pages/Professor/Professores.vue') },
      { path: '/professor/public', component: () => import('src/pages/ProfessorPublic/Professores.vue') },
      { path: '/professor/adicionar', component: () => import('src/pages/Professor/ProfessorAdicionar.vue') },
      { path: '/professor/editar/:id', component: () => import('src/pages/Professor/ProfessorEditar.vue') },
      { path: '/artemarcial', component: () => import('src/pages/ArteMarcial/ArteMarcial.vue') },
      { path: '/artemarcial/public', component: () => import('src/pages/ArteMarcialPublic/ArteMarcial.vue') },
      { path: '/artemarcial/adicionar', component: () => import('src/pages/ArteMarcial/ArteMarcialAdicionar.vue') },
      { path: '/artemarcial/editar/:id', component: () => import('src/pages/ArteMarcial/ArteMarcialEditar.vue') },
      { path: '/usuario', component: () => import('src/pages/Usuario/Usuario.vue') },
      { path: '/usuario/adicionar', component: () => import('src/pages/Usuario/UsuarioAdicionar.vue') }

    ]
  },
  {
    path: '/login',
    component: () => import('layouts/LoginLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Login.vue') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
