import axios from 'axios'

export const http = axios.create({ 
  baseURL: 'http://localhost:5000/api', 
  headers : { "Authorization" : "Bearer " + localStorage.getItem('token') } 
})

export default {

  entrar(usuario) {
    return http.post('/usuario/login', usuario)
  },

  getFuncao(id) {
    return http.get('/funcao/usuario/' + id)
  },

  getUsuarios() {
    return http.get('/usuario')
  },

  postUsuario(usuario) {
    return http.post('/usuario/cadastrar', usuario)
  },

  removerUsuario(id) {
    return http.delete('/usuario/' + id)
  },

  ativarAluno(id) {
    return http.patch('aluno/ativar/' + id )
  },

  desativarAluno(id) {
    return http.patch('aluno/desativar/' + id )
  },

  ativarProfessor(id) {
    return http.patch('professor/ativar/' + id )
  },

  desativarProfessor(id) {
    return http.patch('professor/desativar/' + id )
  },

  getAlunos() {
    return http.get('/aluno')
  },

  getAlunosAtivo() {
    return http.get('/aluno/status/' + true)
  },

  getAlunoById(id) {
    return http.get('/aluno/' + id)
  },

  updateAluno(aluno, id) {
    return http.patch('/aluno/' + id, aluno)
  },

  getProfessores() {
    return http.get('/professor')
  },

  getProfessoresAtivo() {
    return http.get('/professor/status/' + true)
  },

  getProfessorById(id) {
    return http.get('/professor/' + id)
  },

  postProfessor(professor) {
    return http.post('/professor/', professor)
  },

  updateProfessor(professor, id) {
    return http.patch('/professor/' + id, professor)
  },

  removerProfessor(id) {
    return http.delete('/professor/' + id)
  },

  removerAluno(id) {
    return http.delete('/aluno/' + id)
  },

  postAluno(aluno) {
    return http.post('/aluno/', aluno)
  },

  getArtesMarciais() {
    return http.get('/artemarcial')
  },
  
  getArtesMarciaisAtivo() {
    return http.get('/artemarcial/status/' + true)
  },

  postArteMarcial(arteMarcial) {
    return http.post('/artemarcial/', arteMarcial)
  },

  getArteMarcialId(id) {
    return http.get('/artemarcial/' + id)
  },

  updateArteMarcial(arteMarcial, id) {
    return http.patch('/artemarcial/' + id, arteMarcial)
  },


  desativarAtivarArteMarcial(id, arteMarcial) {
    return http.patch('artemarcial/' + id, arteMarcial )
  },

  removerArteMarcial(id) {
    return http.delete('artemarcial/' + id )
  },

  getAlunoArtesMarciais(id) {
    return http.get('/alunoartemarcial/' + id)
  },

  salvarAlunoArtesMarciais(alunoartemarcial) {
    return http.post('/alunoartemarcial', alunoartemarcial);
  },

  removerAlunoArtesMarciais(idAluno, idArteMarcial) {
    return http.delete('/alunoartemarcial/aluno/' + idAluno + '/artemarcial/' + idArteMarcial);
  }
  
}