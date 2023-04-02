import pygame as pg
from time import time
from random import choice, uniform

class DDCR:
    def __init__(self, font):
        self.score = 0
        self.combo = 0

        self.font = font

        self.positions = []

        self.current_display_text = ""
        self.display_time = 0.0

        self.screen_shake = [0, 0]

        # Positions of form ["L", 100]
        self.actions = ["L_R", "L_L", "R_R", "R_L", "U_R", "U_L", "D_R", "D_L"]

        self.images = {
            "L_R": pg.image.load("left_right.png"),
            "L_L": pg.image.load("left_left.png"),
            "R_R": pg.image.load("right_right.png"),
            "R_L": pg.image.load("right_left.png"),
            "U_R": pg.image.load("up_right.png"),
            "U_L": pg.image.load("up_left.png"),
            "D_R": pg.image.load("down_right.png"),
            "D_L": pg.image.load("down_left.png")
        }

        # Adjust the values
        self.column_positions = {"L_R": 200,
                                 "L_L": 400,
                                 "R_R": 600,
                                 "R_L": 800,
                                 "U_R": 1000,
                                 "U_L": 1200,
                                 "D_R": 1400,
                                 "D_L": 1600}

    def update_positions(self) -> None:
        for pos in self.positions:
            pos[1] += 3

        self.positions = [pos for pos in self.positions if pos[1] < 1000]  # Removes positions out of range

    def draw_positions(self, local_screen) -> None:
        for pos in self.positions:
            local_screen.blit(
                self.images[pos[0]],  # Displays the image
                (self.column_positions[pos[0]] + self.screen_shake[0], pos[1] + self.screen_shake[1])
                # Displays it in the right column at its current position
            )

    def gen_new_position(self) -> None:
        self.positions.append([choice(self.actions), 0])

    def display_hit(self, text: str) -> None:
        self.current_display_text = text
        self.display_time = 3.0

    def get_score_gained(self, action: str) -> None:
        mid_value = 800
        for pos in self.positions:
            if action == pos[0]:
                if (mid_value - 5) <= pos[1] <= (mid_value + 5):
                    self.score += 100 + (10 * self.combo)
                    self.display_hit("PERFECT")
                    self.screen_shake[0] += uniform(-(7 + self.combo * 1.5), (7 + self.combo * 1.5))
                    self.screen_shake[1] += uniform(-(7 + self.combo * 1.5), (7 + self.combo * 1.5))
                    self.combo += 1
                elif (mid_value - 15) <= pos[1] <= (mid_value + 15):
                    self.score += 60 + (5 * self.combo)
                    self.display_hit("NICE")
                    self.screen_shake[0] += uniform(-(1.5 + self.combo), (1.5 + self.combo))
                    self.screen_shake[1] += uniform(-(1.5 + self.combo), (1.5 + self.combo))
                    self.combo += 1
                elif (mid_value - 25) <= pos[1] <= (mid_value + 25):
                    self.score += 20 + self.combo
                    self.display_hit("OK")
                    self.screen_shake[0] += uniform(-(self.combo * 0.2), (self.combo * 0.2))
                    self.screen_shake[1] += uniform(-(self.combo * 0.2), (self.combo * 0.2))
                    self.combo += 1
                else:
                    self.display_hit("FAIL")
                    self.screen_shake[0] += uniform(-5, 5)
                    self.screen_shake[1] += uniform(-5, 5)
                    self.combo = 0

    def screen_shake_update(self):
        self.screen_shake[0] *= uniform(0.3, 0.6)
        self.screen_shake[1] *= uniform(0.3, 0.6)


pg.font.init()
game = DDCR(pg.font.SysFont("Comic Sans MS", 30))
(width, height) = (1920, 1080)
background_colour = [0, 0, 0]

screen = pg.display.set_mode((width, height))

pg.display.set_caption("DDCR")
screen.fill(background_colour)

pg.display.flip()

running = True

while running:
    for event in pg.event.get():
        if event.type == pg.QUIT:
            running = False
    prev_time = time()
    screen.fill(background_colour)
    if uniform(0, 100) > 98:
        game.gen_new_position()
    game.update_positions()
    game.draw_positions(screen)
    if game.display_time > 0.0:
        display_subscreen = game.font.render(game.current_display_text, False, (250, 0, 247))
        screen.blit(display_subscreen, (300 + game.screen_shake[0], 300 + game.screen_shake[1]))
        game.display_time -= time() - prev_time
    game.get_score_gained("L_L")
    game.screen_shake_update()
    line_width = int(max([abs(game.screen_shake[0]), abs(game.screen_shake[1]), 1]))
    pg.draw.line(screen, (0, 0, 0), (0, 795), (2000, 795), line_width)
    pg.draw.line(screen, (0, 0, 0), (0, 805), (2000, 805), line_width)
    pg.draw.line(screen, (214, 44, 215), (0, 785), (2000, 785), line_width)
    pg.draw.line(screen, (214, 44, 215), (0, 815), (2000, 815), line_width)
    pg.draw.line(screen, (250, 0, 247), (0, 765), (2000, 765), line_width)
    pg.draw.line(screen, (250, 0, 247), (0, 835), (2000, 835), line_width)
    pg.display.flip()

