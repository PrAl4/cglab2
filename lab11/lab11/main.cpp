#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>

void SetIcon(sf::Window& wnd);
void Init();
void Draw();
void InitShader();


void ShaderLog(unsigned int shader)
{
    int infologLen = 0;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        int charsWritten = 0;
        std::vector<char> infoLog(infologLen);
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
        std::cout << "InfoLog: " << infoLog.data() << std::endl;
    }
}


const char* FragShaderSource = R"(
#version 330 core
out vec4 color;
void main() {
gl_FragColor = color;
}
)";

const char* VertexShaderSource = R"(
#version 330 core
in vec2 coord;
void main() {
gl_Position = vec4(coord, 0.0, 1.0);
}
)";



// ID шейдерной программы
GLuint prog;
// ID атрибута
GLint Attrib_vertex;
// ID Vertex Buffer Object
GLuint VBO;
//ID Uniform
GLuint id_loc;

struct Vertex {
    GLfloat x;
    GLfloat y;
};

void InitVBO() {
    glGenBuffers(1, &VBO);
    // Вершины нашего треугольника
    Vertex squard[4] = {
   { -0.5f, -0.5f },
   { -0.5f, 0.5f },
   { 0.5f, 0.5f },
   { 0.5f, -0.5f }
    };
    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(squard), squard, GL_STATIC_DRAW);
    // checkOpenGLerror(); //Пример функции есть в лабораторной
     // Проверка ошибок OpenGL, если есть, то вывод в консоль тип ошибки
}

void InitShader() {

    GLuint vert = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vert, 1, &VertexShaderSource, NULL);
    glCompileShader(vert);
    ShaderLog(vert);
    // ID шейдерной программы
    GLuint frag = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(frag, 1, &FragShaderSource, NULL);
    glCompileShader(frag);
    ShaderLog(frag);

    prog = glCreateProgram();
    glAttachShader(prog, frag);
    glAttachShader(prog, vert);
    glLinkProgram(prog);

    int link_ok;
    glGetProgramiv(prog, GL_LINK_STATUS, &link_ok);
    if (!link_ok) {
        std::cout << "error attach shaders \n";
        return;
    }

    const char* attr_name = "coord";
    Attrib_vertex = glGetAttribLocation(prog, attr_name);
    if (Attrib_vertex == -1) {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }
}


// Функция непосредственно отрисовки сцены
void Draw() {

    glUseProgram(prog);
    glEnableVertexAttribArray(Attrib_vertex);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0);
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    float Color[4] = { 0.5f, 0.10f, 0.1f, 0.5f };
    id_loc = glGetUniformLocation(prog, "color");
    glUniform4f(id_loc, Color[0], Color[1], Color[2], Color[3]);
    //здесь рисуем квадрат GL_POLYGON
    glDrawArrays(GL_POLYGON, 0, 4);
    glDisableVertexAttribArray(Attrib_vertex);
    glUseProgram(0);
}


// В момент инициализации разумно произвести загрузку текстур, моделей и других вещей
void Init() {

    InitShader();

    InitVBO();

}

// Освобождение буфера
void ReleaseVBO() {
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO);
}

// Освобождение шейдеров
void ReleaseShader() {
    // Передавая ноль, мы отключаем шейдерную программу
    glUseProgram(0);
    // Удаляем шейдерную программу
    glDeleteProgram(prog);
}


void Release() {
    // Шейдеры
    ReleaseShader();
    // Вершинный буфер
    ReleaseVBO();
}


int main() {
    sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);
    window.setActive(true);
    glewInit();
    Init();
    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) { window.close(); }
            else if (event.type == sf::Event::Resized) { glViewport(0, 0, event.size.width, event.size.height); }
        }
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        Draw();
        window.display();
    }
    Release();
    return 0;
}